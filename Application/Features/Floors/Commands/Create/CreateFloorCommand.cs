using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Floors.Commands.Create
{
    public class CreateFloorCommand : IRequest<CreateFloorResponse>
    {
        public string No { get; set; }
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
                Floor floor = _mapper.Map<Floor>(request);
                await _floorRepository.AddAsync(floor);

                CreateFloorResponse response = _mapper.Map<CreateFloorResponse>(floor);
                return response;
            }
        }
    }
}
