using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Allergies.Queries.GetListAllergy
{
    public class GetListAllergyQuery : IRequest<GetListAllergyResponse>
    {
        public class GetListAllergyQueryHandler  :IRequestHandler<GetListAllergyQuery, GetListAllergyResponse>
        {
            private readonly IAllergyRepository _allergyRepository;

            public GetListAllergyQueryHandler(IAllergyRepository allergyRepository, IMapper mapper)
            {
                _allergyRepository = allergyRepository;
            }

            public async Task<GetListAllergyResponse> Handle(GetListAllergyQuery request, CancellationToken cancellationToken)
            {
                GetListAllergyResponse response = new GetListAllergyResponse();
                response.Allergies = await _allergyRepository.GetListAsync();
                return response;
            }
        }
    }
}
