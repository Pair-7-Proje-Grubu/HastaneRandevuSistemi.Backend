using Application.Features.Appointments.Commands.Book;
using Application.Features.Appointments.Queries.GetListActiveAppointment;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.MappingProfiles
{
    public class AppointmentMappingProfiles : Profile
    {
        public AppointmentMappingProfiles() 
        {
            CreateMap<Appointment, BookAppointmentCommand>().ReverseMap();
            CreateMap<Appointment, BookAppointmentResponse>().ReverseMap();
            CreateMap<Appointment, GetListActiveAppointmentByDoctorResponse>().ReverseMap();
        }
    }
}
