using Application.Features.OperationClaims.Commands.Create;
using Application.Features.OperationClaims.Queires.GetListOperationClaim;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.MappingProfiles
{
    public class OperationClaimProfile : Profile
    {
        public OperationClaimProfile()
        {
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimResponse>().ReverseMap();
            CreateMap<OperationClaim, GetListOperationClaimQuery>().ReverseMap();
            CreateMap<OperationClaim, GetListOperationClaimResponse>().ReverseMap();
        }
    }
}
