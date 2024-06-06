using Application.Features.Reports.Commands.Create;
using Application.Features.Reports.Commands.Update;
using Application.Features.Reports.Queries.GetById;
using Application.Features.Reports.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.MappingProfiles
{
    public class ReportMappingProfiles : Profile
    {
        public ReportMappingProfiles()
        {
            CreateMap<Report, CreateReportCommand>().ReverseMap();
            CreateMap<Report, CreateReportResponse>().ReverseMap();

            CreateMap<Report, UpdateReportCommand>().ReverseMap();
            CreateMap<Report, UpdateReportResponse>().ReverseMap();

            CreateMap<Report, GetListReportResponse>().ReverseMap();
            CreateMap<Report, GetByIdReportResponse>().ReverseMap();
        }
    }
}
