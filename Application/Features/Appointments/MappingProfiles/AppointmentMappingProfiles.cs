using Application.Features.Appointments.Commands.Book;
using Application.Features.Appointments.Commands.CancelByPatient;
using Application.Features.Appointments.Queries.GetListActiveAppointment;
using Application.Features.Appointments.Queries.GetListAppointment;
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
            CreateMap<Appointment, CancelAppointmentByPatientResponse>().ReverseMap();
            CreateMap<Appointment, GetListActiveAppointmentByDoctorResponse>().ReverseMap();
            CreateMap<Appointment, GetListAppointmentResponse>()
            .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime))
            .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor.User.FirstName + " " + src.Doctor.User.LastName))
            .ForMember(dest => dest.Clinic, opt => opt.MapFrom(src => src.Doctor.Clinic.Name))
            .ForMember(dest => dest.OfficeLocation, opt => opt.MapFrom(src => $"Blok: '{src.Doctor.OfficeLocation.Block.No}', Kat: '{src.Doctor.OfficeLocation.Floor.No}', Oda: '{src.Doctor.OfficeLocation.Room.No}'"));
        }
    }
}
