using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clinics.Commands.Queries.GetListClinic
{
    public class GetListClinicQuery : IRequest<GetListClinicResponse>
    {
       
        public class GetListClinicQueryHandler : IRequestHandler<GetListClinicQuery, GetListClinicResponse>
        {
            private readonly IClinicRepository _clinicRepository;

            public GetListClinicQueryHandler(IClinicRepository clinicRepository, IMapper mapper)
            {
                _clinicRepository = clinicRepository;
            }

            public async Task<GetListClinicResponse> Handle(GetListClinicQuery request, CancellationToken cancellationToken)
            {
                GetListClinicResponse response = new GetListClinicResponse();
                response.Clinics = await _clinicRepository.GetListAsync();
                return response;
            }


        }

    }
}
