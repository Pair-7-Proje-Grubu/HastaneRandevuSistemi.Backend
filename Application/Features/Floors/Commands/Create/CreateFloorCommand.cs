using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Floors.Commands.Create
{
    public class CreateFloorCommand : IRequest<CreateFloorResponse>,ISecuredRequest
    {
        public string No { get; set; }

        public string[] RequiredRoles => ["Admin"];
        public class CreateFloorCommandHandler : IRequestHandler<CreateFloorCommand, CreateFloorResponse>
        {
            private readonly IFloorRepository _floorRepository;
            private readonly IMapper _mapper;
            public CreateFloorCommandHandler(IFloorRepository floorRepository, IMapper mapper)
            {
                _floorRepository = floorRepository;
                _mapper = mapper;
            }
            public async Task<CreateFloorResponse> Handle(CreateFloorCommand request, CancellationToken cancellationToken)
            {
                Floor? floorWithSameNo = await _floorRepository.GetAsync(p => p.No == request.No);
                if (floorWithSameNo is not null)
                {
                    throw new BusinessException("Kat No daha önceden sisteme kaydedilmiş");
                }
                Floor floor = _mapper.Map<Floor>(request);
                await _floorRepository.AddAsync(floor);

                CreateFloorResponse response = _mapper.Map<CreateFloorResponse>(floor);
                return response;
            }
        }
    }
}
