using Application.Features.Appointments.Dtos;
using Application.Features.Clinics.Rules;
using Application.Features.Doctors.Queries.GetListDoctor;
using Application.Features.Doctors.Rules;
using Application.Features.WorkingTimes.Rules;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Application.Features.Appointments.Queries.GetListAvailableAppointment
{

    public class GetListAvailableAppointmentQuery : IRequest<GetListAvailableAppointmentResponse>
    {
        public int DoctorId { get; set; }

        public class GetListAvailableAppointmentQueryHandler : IRequestHandler<GetListAvailableAppointmentQuery, GetListAvailableAppointmentResponse>
        {

            private readonly IDoctorRepository _doctorRepository;
            private readonly IWorkingTimeRepository _workingTimeRepository;
            private readonly DoctorBusinessRules _doctorBusinessRules;
            private readonly WorkingTimeBusinessRules _workingTimeBusinessRules;
            private readonly ClinicBusinessRules _clinicBusinessRules;

            public GetListAvailableAppointmentQueryHandler(IDoctorRepository doctorRepository, IMapper mapper, IWorkingTimeRepository workingTimeRepository, DoctorBusinessRules doctorBusinessRules, WorkingTimeBusinessRules workingTimeBusinessRules, ClinicBusinessRules clinicBusinessRules)
            {
                _doctorRepository = doctorRepository;
                _workingTimeRepository = workingTimeRepository;
                _doctorBusinessRules = doctorBusinessRules;
                _workingTimeBusinessRules = workingTimeBusinessRules;
                _clinicBusinessRules = clinicBusinessRules;
            }

            public async Task<GetListAvailableAppointmentResponse> Handle(GetListAvailableAppointmentQuery request, CancellationToken cancellationToken)
            {
                //EĞER RANDEVU ZAMANI DOKTORUN MÜSAİT OLMADIĞI VAKİTLERDEYSE  VEYA MOLA VAKTİNDEYSE KULLANICIYA O ZAMAN AİT RANDEVULAR GÖSTERİLMEMEKTEDİR.
                //RANDEVU ALINAN VAKİTLERİ İSE KULLANICININ GÖREBİLMESİ UYGUN GÖRÜLMÜŞTÜR.
                //BUNDAN KAYNAKLI ALINAN RANDEVULAR ÇALIŞMA ZAMANINI ETKİLEMEZ YALNIZCA FRONTEND'E GÖNDERİLİR Kİ ALINDIĞI BELLİ OLSUN.

                await _doctorBusinessRules.DoctorIdShouldExistWhenSelected(request.DoctorId);
                await _workingTimeBusinessRules.MostRecentWorkingTimeShouldExistWhenSelected();


                int dayLimit = 15;

                Doctor doctor = (await _doctorRepository.GetAsync(
                    d => d.Id == request.DoctorId,
                    include: d =>
                        d.Include(d => d.Clinic)
                        .Include(d => d.Appointments.Where(a => a.DateTime > DateTime.Now && a.DateTime < DateTime.Now.AddDays(dayLimit)))
                        .Include(d => d.DoctorNoWorkHours.Where(nwh => nwh.NoWorkHour.StartDate.Date >= DateTime.Now.Date && nwh.NoWorkHour.EndDate.Date <= DateTime.Now.AddDays(dayLimit).Date))
                            .ThenInclude(d => d.NoWorkHour), asNoTracking: true))!;

                await _clinicBusinessRules.ClinicShouldExistWhenSelected(doctor.Clinic);
                await _clinicBusinessRules.AppointmentDurationShouldBePositiveWhenSelected(doctor.Clinic.AppointmentDuration);

                WorkingTime workingTime = (await _workingTimeRepository.GetMostRecentAsync(true))!;



                GetListAvailableAppointmentResponse response = new GetListAvailableAppointmentResponse();
                response.AppointmentDates = new List<AppointmentDate>();
                response.AppointmentDuration = doctor.Clinic.AppointmentDuration;

                for (int i = 0; i < dayLimit; i++)
                {
                    TimeSpan startTime, endTime;
                    startTime = workingTime.StartTime;
                    endTime = workingTime.EndTime;

                    DateTime currentDate = DateTime.Now.AddDays(i).Date;

                    //Doktorun o günkü tüm müsait olmadığı vakitlerin küsüratını kaldırıp randevu vaktine çekiyoruz.
                    //Örneğin doktor 15 dakikalık randevular veriyorsa ve müsait olmadığı vakit 14:42 ise 14:45'e çekiyoruz.
                    List<NoWorkHour>? noWorkHours = doctor.DoctorNoWorkHours.Select(d=>d.NoWorkHour).Where(nwh => nwh.StartDate.Date == currentDate)
                        .Select(nwh =>
                        {
                            nwh.StartDate = RoundUpToNextAppointmentTimeDateTime(nwh.StartDate,doctor.Clinic.AppointmentDuration);
                            nwh.EndDate = RoundUpToNextAppointmentTimeDateTime(nwh.EndDate, doctor.Clinic.AppointmentDuration);
                            return nwh;
                        }).ToList();
                    
                    //İş yerinin mola vaktinide varsayılan olarak ekliyoruz.
                    noWorkHours.Add(new NoWorkHour() { StartDate = currentDate.Add(workingTime.StartBreakTime), EndDate = currentDate.Add(workingTime.EndBreakTime) });


                    //Bugüne ait geçmiş randevuları getirmemesi için çalışma zaman aralığını düzenliyoruz.
                    if (currentDate == DateTime.Now.Date)
                    {
                        TimeSpan timeOfToday = DateTime.Now.TimeOfDay;
                        if (timeOfToday >= workingTime.StartTime && timeOfToday <= workingTime.EndTime)
                        {
                            startTime = timeOfToday;
                        }
                        else if (timeOfToday > workingTime.EndTime)
                        {
                            continue;
                        }
                    }

                    //Çalışma saat aralığını randevu saatine uygun hale getiriyoruz. (Dakikadaki küsüratları yuvarlıyoruz.)
                    startTime = RoundUpToNextAppointmentTimeTimeSpan(startTime, doctor.Clinic.AppointmentDuration);
                    endTime = RoundUpToNextAppointmentTimeTimeSpan(endTime, doctor.Clinic.AppointmentDuration);

                    List<DateTimeRange> availableRangesOfDay = CalculateAvailableDateTimeRanges(startTime, endTime, noWorkHours);
                    if (availableRangesOfDay.Any())
                    {
                        //List<DateTimeRange> availableRangesOfDay = CalculateAvailableDateTimeRanges(startTime, endTime, noWorkHours).Select(x => new DateRange() { StartTime = x.Start.TimeOfDay, EndTime = x.End.TimeOfDay }).ToList();
                        response.AppointmentDates.Add(new AppointmentDate()
                        {
                            //Önceden alınmış randevular
                            BookedSlots = doctor.Appointments.Where(d => d.DateTime.Date == currentDate).Select(x => x.DateTime.TimeOfDay).ToList(),
                            //Gün
                            Date = currentDate,
                            //Güne ait tüm müsait aralıkların sadece "time" değerlerini yazdırıyoruz.
                            Ranges = availableRangesOfDay.Select(x => new DateRange() { StartTime = x.Start.TimeOfDay, EndTime = x.End.TimeOfDay }).ToList()
                        });
                    }
                  
                }
                return response;
            }

            public TimeSpan RoundUpToNextAppointmentTimeTimeSpan(TimeSpan time, int appointmentDuration)
            {
                int minutes = time.Minutes;
                int additionalMinutes = (appointmentDuration - minutes % appointmentDuration) % appointmentDuration;

                return new TimeSpan(
                    time.Hours,
                    time.Minutes + additionalMinutes,
                    0  // Saniyeyi sıfırlıyoruz
                ).Add(TimeSpan.FromHours(Math.Floor((double)(time.Minutes + additionalMinutes) / 60)));
            }

            public DateTime RoundUpToNextAppointmentTimeDateTime(DateTime dateTime, int appointmentDuration)
            {
                var minutes = dateTime.Minute;
                var mod = minutes % appointmentDuration;
                var additionalMinutes = mod == 0 ? 0 : appointmentDuration - mod;

                return dateTime.AddMinutes(additionalMinutes).AddSeconds(-dateTime.Second);
            }

            public List<DateTimeRange> CalculateAvailableDateTimeRanges(TimeSpan startTime, TimeSpan endTime, List<NoWorkHour> noWorkHours)
            {
                var baseDate = noWorkHours.Min(s => s.StartDate.Date);
                var workingHours = new DateTimeRange(
                baseDate.Add(startTime),
                baseDate.Add(endTime)
                );

                var availableRanges = new List<DateTimeRange> { workingHours };

                //Tüm müsait olunmayan aralıkları başlangıc saati en erken olana göre sıralayarak getir ve gez.
                foreach (var unavailableRange in noWorkHours.OrderBy(s => s.StartDate))
                {
                    var newAvailableRanges = new List<DateTimeRange>();
                    //Tüm müsait aralıkları gez.
                    foreach (var availableRange in availableRanges)
                    {
                        //Müsait olduğu vakitten müsait olmadığı vakti çıkart. (Bu sayede 2 aralık elde ediyoruz.)
                        List<DateTimeRange> ranges = SplitTimeRange(availableRange, unavailableRange);

                        newAvailableRanges.AddRange(ranges);
                    }

                    //Müsait aralıkları yeni müsait aralıklarıyla güncelle. (bölünme işlemini yaptıktan sonraki son haliyle güncelliyoruz.)
                    availableRanges = newAvailableRanges.Where(a => a.Start < a.End).ToList();
                }
            
                return availableRanges;
            }

            private static List<DateTimeRange> SplitTimeRange(DateTimeRange available, NoWorkHour noWorkHour)
            {
                var result = new List<DateTimeRange>() {  };

                //Tüm gün müsait değilse boş döndür.
                if (noWorkHour.StartDate <= available.Start && noWorkHour.EndDate >= available.End)
                {
                    return result;
                }

                //Eğer mesai başladıktan sonra müsait değilse;
                if (noWorkHour.StartDate > available.Start)
                {
                    //Aralığın başlangıç vakti: mesai vakti olarak ayarla.
                    //Aralığın bitiş vakti: mesai bitmeden mola vakti başlıyorsa mola vaktinin başlangıcı, değilse mesai'nin bitişi
                    result.Add(new DateTimeRange(available.Start, noWorkHour.StartDate < available.End ? noWorkHour.StartDate : available.End));
                }

                //Eğer müsait olmadığı vakit mesai bitmeden bitiyor ise;
                if (noWorkHour.EndDate < available.End)
                {
                    //Aralığın başlangıç vakti: mola bitişi mesaiden sonraysa mola bitişi, değilse mesai'nin başlangıcı
                    //Aralığın bitiş vakti: günün bitiş vakti
                    result.Add(new DateTimeRange(noWorkHour.EndDate > available.Start ? noWorkHour.EndDate : available.Start, available.End));
                }

                return result;
            }

            public class DateTimeRange
            {
                public DateTime Start { get; set; }
                public DateTime End { get; set; }

                public DateTimeRange(DateTime start, DateTime end)
                {
                    Start = start;
                    End = end;
                }
            }


        }
    }
}
