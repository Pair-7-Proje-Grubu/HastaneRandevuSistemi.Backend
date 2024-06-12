using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Allergies.Commands.Update
{
    public class UpdateAllergyCommand : IRequest<UpdateAllergyResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateAllergyCommandHandler : IRequestHandler<UpdateAllergyCommand, UpdateAllergyResponse>
        {
            private readonly IAllergyRepository _allergyRepository;
            private readonly IMapper _mapper;

            public UpdateAllergyCommandHandler(IAllergyRepository allergyRepository, IMapper mapper)
            {
                _allergyRepository = allergyRepository;
                _mapper = mapper;
            }

            public async Task<UpdateAllergyResponse> Handle(UpdateAllergyCommand request, CancellationToken cancellationToken)
            {
                Allergy allergy = _mapper.Map<Allergy>(request);
                await _allergyRepository.UpdateAsync(allergy);
                UpdateAllergyResponse response = _mapper.Map<UpdateAllergyResponse>(allergy);
                return response;
            }
        }
    }
}
