using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Clinics.Queries.GetListClinic;
using Application.Features.Clinics.Dtos;

namespace Application.Features.Clinics.Queries.GetListClinic
{
    public class GetListClinicQuery : IRequest<List<GetListClinicDto>>
    {
       
        public class GetListClinicQueryHandler : IRequestHandler<GetListClinicQuery, List<GetListClinicDto>>
        {
            private readonly IClinicRepository _clinicRepository;
            private readonly IMapper _mapper;
            

            public GetListClinicQueryHandler(IClinicRepository clinicRepository, IMapper mapper)
            {
                _clinicRepository = clinicRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListClinicDto>> Handle(GetListClinicQuery request, CancellationToken cancellationToken)
            {
                List<Clinic> clinics = await _clinicRepository.GetListAsync();
                List<GetListClinicDto> response = _mapper.Map<List<GetListClinicDto>>(clinics);
                 
                return response;
            }
            

        }

    }
}
