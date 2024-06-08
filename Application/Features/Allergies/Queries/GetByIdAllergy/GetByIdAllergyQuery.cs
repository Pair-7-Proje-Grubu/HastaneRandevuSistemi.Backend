using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Allergies.Queries.GetByIdAllergy
{
    public class GetByIdAllergyQuery : IRequest<GetByIdAllergyResponse>
    {
        public int Id { get; set; }

        public class GetByIdAllergyQueryHandler : IRequestHandler<GetByIdAllergyQuery, GetByIdAllergyResponse>
        {

            private IAllergyRepository _allergyRepository;
            private IMapper _mapper;    

            public GetByIdAllergyQueryHandler(IAllergyRepository allergyRepository, IMapper mapper)
            {
                _allergyRepository = allergyRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdAllergyResponse> Handle(GetByIdAllergyQuery request, CancellationToken cancellationToken)
            {

                Allergy? allergy = await _allergyRepository.GetAsync(x => x.Id == request.Id);

                GetByIdAllergyResponse response = new GetByIdAllergyResponse();
                response.Allergy = allergy;

                return response;
            }
        }
    }
}
