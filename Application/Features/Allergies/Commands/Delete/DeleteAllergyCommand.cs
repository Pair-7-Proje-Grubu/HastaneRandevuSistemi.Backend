using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Allergies.Commands.Delete
{
    public class DeleteAllergyCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteAllergyCommandHandler : IRequestHandler<DeleteAllergyCommand>
        {
            private IAllergyRepository _allergyRepository;
            private readonly IMapper _mapper;

            public DeleteAllergyCommandHandler(IAllergyRepository allergyRepository, IMapper mapper)
            {
                _allergyRepository = allergyRepository;
                _mapper = mapper;
            }

            public async Task Handle(DeleteAllergyCommand request, CancellationToken cancellation)
            {
                Allergy? allergy = _mapper.Map<Allergy>(request);

                if (allergy is null)
                    throw new Exception("Böyle bir alerji bulunamadı.");

                await _allergyRepository.DeleteAsync(allergy);
            }
        }



  



    }
}
