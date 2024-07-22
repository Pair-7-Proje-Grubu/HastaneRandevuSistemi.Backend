using AutoMapper;
using MediatR;
using Domain.Entities;
using Application.Repositories;
using Core.Application.Pipelines.Authorization;

namespace Application.Features.Allergies.Commands.Create
{
    public class CreateAllergyCommand :IRequest<CreateAllergyResponse>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] RequiredRoles => ["Admin"];  
    
    }

    public class CreateAllergyCommandHandler : IRequestHandler<CreateAllergyCommand, CreateAllergyResponse>
    {
        private readonly IAllergyRepository _allergyRepository;
        private readonly IMapper _mapper;

        public CreateAllergyCommandHandler(IAllergyRepository allergyRepository, IMapper mapper)
        {
            _allergyRepository = allergyRepository;
            _mapper = mapper;
        }

        public async Task<CreateAllergyResponse> Handle(CreateAllergyCommand request, CancellationToken cancellationToken)
        {
            Allergy allergy = _mapper.Map<Allergy>(request);
            await _allergyRepository.AddAsync(allergy);
            return new CreateAllergyResponse() { Id = allergy.Id, Name = allergy.Name, };
        }
    }
}
