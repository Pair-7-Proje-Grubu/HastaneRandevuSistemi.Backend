using Application.Features.Appointments.Commands.Book;
using Application.Features.Appointments.Commands.Cancel.FromDoctor;
using Application.Features.Appointments.Queries.GetListActiveAppointment;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
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
            CreateMap<Appointment, CancelAppointmentFromDoctorCommand>().ReverseMap();
            CreateMap<Appointment, CancelAppointmentFromDoctorResponse>()
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient.FirstName + " " + src.Patient.LastName))
                .ForMember(dest => dest.isCancelStatus, opt => opt.MapFrom(src => CancelStatus.FromDoctor))
                .ReverseMap()
                .ForPath(dest => dest.Patient.FirstName, opt => opt.Ignore())
                .ForPath(dest => dest.Patient.LastName, opt => opt.Ignore());
        }
    }
}
