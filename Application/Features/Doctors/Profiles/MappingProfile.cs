using Application.Features.Doctors.Commands.CreateDoctor;
using Application.Features.Doctors.Commands.UpdateDoctor;
using Application.Features.Doctors.Queries.GetByClinicIdDoctor;
using Application.Features.Doctors.Queries.GetByIdDoctor;
using Application.Features.Floors.Queries.GetById;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Doctor, CreateDoctorCommand>().ReverseMap();
            CreateMap<Doctor, UpdateDoctorCommand>().ReverseMap();
            CreateMap<Doctor, GetByIdDoctorResponse>().ReverseMap();
            CreateMap<Doctor, GetByClinicIdDoctorResponse>()
             .ForMember(dest => dest.TitleName, opt => opt.MapFrom(src => src.Title.TitleName))
             .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
             .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
             .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.User.Gender));
        }
    }
}
