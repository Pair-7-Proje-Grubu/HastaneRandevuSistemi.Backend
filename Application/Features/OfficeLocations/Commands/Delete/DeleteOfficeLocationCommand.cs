using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.OfficeLocations.Commands.Delete
{
    public class DeleteOfficeLocationCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteOfficeLocationCommandHandler : IRequestHandler<DeleteOfficeLocationCommand>
        {
            private IOfficeLocationRepository _officeLocationRepository;
            private readonly IMapper _mapper;

            public DeleteOfficeLocationCommandHandler(IOfficeLocationRepository officeLocationRepository, IMapper mapper)
            {
                _officeLocationRepository = officeLocationRepository;
                _mapper = mapper;
            }

            public async Task Handle(DeleteOfficeLocationCommand request, CancellationToken cancellationToken)
            {
                OfficeLocation? officeLocation = await _officeLocationRepository.GetAsync(i => i.Id == request.Id);
                if (officeLocation is null)
                    throw new ValidationException("Böyle bir veri bulunamadı.");

                await _officeLocationRepository.DeleteAsync(officeLocation);
            }
        }
    }
}
