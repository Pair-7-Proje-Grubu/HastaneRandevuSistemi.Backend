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
                //Clinic? clinic = await _clinicRepository.GetAsync(c => c.Id == request.ClinicId);

                List<Doctor> doctors = await _doctorRepository.GetListAsync(d => d.ClinicId == request.ClinicId, include: d => d.Include(d => d.DoctorNoWorkHours).ThenInclude(d => d.NoWorkHour));

                WorkingTime workingTime = (await _workingTimeRepository.GetListAsync()).MaxBy(x => x.CreatedDate);

                //Start => 09.00 End => 17.00 Break => 12.00-13.00
                //NoWorkStart => 13.00 End => 15.00

                

                List<GetListAvailableDto> responseDtos = new List<GetListAvailableDto>();

                int dayLimit = 10;

                foreach (Doctor doctor in doctors)
                {      
                    GetListAvailableDto dto = new GetListAvailableDto();
                    dto.AppointmentDates = new List<AppointmentDate>();
                    for (int i = 0; i < dayLimit; i++)
                    {
                        List<DateRange> ranges = new List<DateRange>();
                        DoctorNoWorkHour? doctorNoWorkHour = doctor.DoctorNoWorkHours.FirstOrDefault(d => d.NoWorkHour.StartDate.Date == DateTime.Now.AddDays(i).Date);
                        if (doctorNoWorkHour != null)
                        {
                            ranges.Add(new DateRange() { StartTime = workingTime.StartTime, EndTime = doctorNoWorkHour.NoWorkHour.StartDate.TimeOfDay });
                            ranges.Add(new DateRange() { StartTime = doctorNoWorkHour.NoWorkHour.EndDate.TimeOfDay, EndTime = workingTime.EndTime });
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
