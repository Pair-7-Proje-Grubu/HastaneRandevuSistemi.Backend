using Application.Features.Appointments.Dtos;
using Application.Features.Doctors.Queries.GetListDoctor;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetListAvailableAppointment
{

    public class GetListAvailableAppointmentQuery : IRequest<GetListAvailableAppointmentResponse>
    {
        public int ClinicId { get; set; }
        public class GetListAvailableAppointmentQueryHandler : IRequestHandler<GetListAvailableAppointmentQuery, GetListAvailableAppointmentResponse>
        {

            private readonly IDoctorRepository _doctorRepository;
            private readonly IWorkingTimeRepository _workingTimeRepository;

            public GetListAvailableAppointmentQueryHandler(IDoctorRepository doctorRepository, IMapper mapper, IWorkingTimeRepository workingTimeRepository)
            {
                _doctorRepository = doctorRepository;
                _workingTimeRepository = workingTimeRepository;
            }

            public async Task<GetListAvailableAppointmentResponse> Handle(GetListAvailableAppointmentQuery request, CancellationToken cancellationToken)
            {
                List<Doctor> doctors = await _doctorRepository.GetListAsync(d => d.ClinicId == request.ClinicId, include: d => d.Include(d => d.DoctorNoWorkHours).ThenInclude(d => d.NoWorkHour));

                WorkingTime workingTime = (await _workingTimeRepository.GetListAsync()).MaxBy(x => x.CreatedDate);

                List<GetListAvailableDto> responseDtos = new List<GetListAvailableDto>();

                int dayLimit = 10;

                foreach (Doctor doctor in doctors)
                {      
                    GetListAvailableDto dto = new GetListAvailableDto();
                    dto.AppointmentDates = new List<AppointmentDate>();
                    for (int i = 0; i < dayLimit; i++)
                    {
                        List<DateRange> ranges = new List<DateRange>();
                        List<DoctorNoWorkHour>? doctorNoWorkHours = doctor.DoctorNoWorkHours.Where(d => d.NoWorkHour.StartDate.Date == DateTime.Now.AddDays(i).Date).ToList();

                        //if (doctorNoWorkHours.Count > 1)
                        //{

                        //    ranges.Add(new DateRange() { StartTime = workingTime.StartTime, EndTime = doctorNoWorkHours[0].NoWorkHour.StartDate.TimeOfDay });
                        //    ranges.Add(new DateRange() { StartTime = doctorNoWorkHours[0].NoWorkHour.EndDate.TimeOfDay, EndTime = doctorNoWorkHours[1].NoWorkHour.StartDate.TimeOfDay });
                        //    ranges.Add(new DateRange() { StartTime = doctorNoWorkHours[1].NoWorkHour.EndDate.TimeOfDay, EndTime = workingTime.EndTime });

                        //}

                        if (doctorNoWorkHours.Count > 1)
                        {
                            TimeSpan currentStartTime = workingTime.StartTime;
                            foreach (var doctorNoWorkHour in doctorNoWorkHours)
                            {
                                ranges.Add(new DateRange()
                                {
                                    StartTime = currentStartTime,
                                    EndTime = doctorNoWorkHour.NoWorkHour.StartDate.TimeOfDay
                                });

                                currentStartTime = doctorNoWorkHour.NoWorkHour.EndDate.TimeOfDay;
                            }
                            ranges.Add(new DateRange()
                            {
                                StartTime = currentStartTime,
                                EndTime = workingTime.EndTime
                            });
                        }

                        else if(doctorNoWorkHours.Count == 1)
                        {
                            ranges.Add(new DateRange() { StartTime = workingTime.StartTime, EndTime = doctorNoWorkHours[0].NoWorkHour.StartDate.TimeOfDay });
                            ranges.Add(new DateRange() { StartTime = doctorNoWorkHours[0].NoWorkHour.EndDate.TimeOfDay, EndTime = workingTime.EndTime });
                        }
                        else
                        {
                            ranges.Add(new DateRange() { StartTime = workingTime.StartTime, EndTime = workingTime.EndTime});
                        }

                        
                        dto.AppointmentDates.Add(new AppointmentDate()
                        {
                            Date = DateTime.Now.AddDays(i),
                            Range = ranges
                        });
                    }
                    responseDtos.Add(dto);
                }

                GetListAvailableAppointmentResponse response = new GetListAvailableAppointmentResponse();
                response.GetListAvailableDtos = responseDtos;
                return response;
            }
        }
    }
}
