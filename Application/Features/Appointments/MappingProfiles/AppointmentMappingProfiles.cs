using Application.Features.Appointments.Commands.Book;
using Application.Features.Appointments.Commands.Cancel.ByPatient;
using Application.Features.Appointments.Commands.Cancel.ByDoctor;
using Application.Features.Appointments.Queries.GetListActiveAppointment;
using Application.Features.Appointments.Queries.GetListAppointment;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;


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
            CreateMap<Appointment, CancelAppointmentByDoctorCommand>().ReverseMap();
            CreateMap<Appointment, CancelAppointmentByDoctorResponse>()
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient.FirstName + " " + src.Patient.LastName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => AppointmentStatus.CancelByDoctor))
                .ReverseMap()
                .ForPath(dest => dest.Patient.FirstName, opt => opt.Ignore())
                .ForPath(dest => dest.Patient.LastName, opt => opt.Ignore());
            CreateMap<Appointment, GetListAppointmentResponse>()
            .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime))
            .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor.User.FirstName + " " + src.Doctor.User.LastName))
            .ForMember(dest => dest.Clinic, opt => opt.MapFrom(src => src.Doctor.Clinic.Name))
            .ForMember(dest => dest.OfficeLocation, opt => opt.MapFrom(src => $"Blok: '{src.Doctor.OfficeLocation.Block.No}', Kat: '{src.Doctor.OfficeLocation.Floor.No}', Oda: '{src.Doctor.OfficeLocation.Room.No}'"));
        }
    }
}
