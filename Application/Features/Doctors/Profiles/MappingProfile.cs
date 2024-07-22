using Application.Features.Doctors.Commands.CreateDoctor;
using Application.Features.Doctors.Commands.UpdateDoctor;
using Application.Features.Doctors.Commands.UpdateDoctorOfficeLocation;
using Application.Features.Doctors.Queries.GetByClinicIdDoctor;
using Application.Features.Doctors.Queries.GetByIdDoctor;
using Application.Features.Doctors.Queries.GetListDoctorOfficeLocation;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Doctors.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Doctor, CreateDoctorCommand>().ReverseMap();
            CreateMap<Doctor, CreateDoctorResponse>().ReverseMap();
            CreateMap<Doctor, UpdateDoctorCommand>().ReverseMap();
            CreateMap<Doctor, GetByIdDoctorResponse>().ReverseMap();
            CreateMap<Doctor, GetByClinicIdDoctorResponse>()
             .ForMember(dest => dest.TitleName, opt => opt.MapFrom(src => src.Title.TitleName))
             .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
             .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
             .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.User.Gender));
            CreateMap<Doctor, DoctorOfficeLocationListResponse>();
            CreateMap<Doctor, UpdateDoctorOfficeLocationResponse>();

        }
    }
}
