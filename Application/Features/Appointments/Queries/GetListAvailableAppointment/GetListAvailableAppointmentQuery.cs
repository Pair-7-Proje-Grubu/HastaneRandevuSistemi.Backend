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
        public int DoctorId { get; set; }

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
                Doctor? doctor = await _doctorRepository.GetAsync(
                    d => d.Id == request.DoctorId, 
                    include: d => 
                        d.Include(d => d.Clinic)
                        .Include(d=> d.Appointments)
                        .Include(d => d.DoctorNoWorkHours)
                            .ThenInclude(d => d.NoWorkHour));

                WorkingTime workingTime = (await _workingTimeRepository.GetListAsync()).MaxBy(x => x.CreatedDate);

                GetListAvailableAppointmentResponse response = new GetListAvailableAppointmentResponse();
                int dayLimit = 10;

                if (doctor is not null)
                {
                    response.AppointmentDuration = doctor.Clinic.AppointmentDuration;

                    GetListAvailableDto dto = new GetListAvailableDto();
                    response.AppointmentDates = new List<AppointmentDate>();
                    for (int i = 0; i < dayLimit; i++)
                    {
                        List<DateRange> ranges = new List<DateRange>();
                        List<DoctorNoWorkHour>? doctorNoWorkHours = doctor.DoctorNoWorkHours.Where(d => d.NoWorkHour.StartDate.Date == DateTime.Now.AddDays(i).Date).ToList();

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
                        else if (doctorNoWorkHours.Count == 1)
                        {
                            ranges.Add(new DateRange() { StartTime = workingTime.StartTime, EndTime = doctorNoWorkHours[0].NoWorkHour.StartDate.TimeOfDay });
                            ranges.Add(new DateRange() { StartTime = doctorNoWorkHours[0].NoWorkHour.EndDate.TimeOfDay, EndTime = workingTime.EndTime });
                        }
                        else
                        {
                            ranges.Add(new DateRange() { StartTime = workingTime.StartTime, EndTime = workingTime.EndTime });
                        }

                        response.AppointmentDates.Add(new AppointmentDate()
                        {
                            BookedSlots = doctor.Appointments.Where(d => d.DateTime.Date == DateTime.Now.AddDays(i).Date).Select(x=> x.DateTime.TimeOfDay).ToList(),
                            Date = DateTime.Now.AddDays(i).Date,
                            Ranges = ranges
                        });
                    }
                }
               

                return response;
            }
        }
    }
}
