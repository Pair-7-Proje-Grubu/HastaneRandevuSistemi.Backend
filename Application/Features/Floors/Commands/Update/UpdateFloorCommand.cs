using Application.Features.Rooms.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Floors.Commands.Update
{
    public class UpdateFloorCommand : IRequest<UpdateFloorResponse>, ISecuredRequest
    {
        public int Id { get; set; }

        public string No { get; set; }

        public string[] RequiredRoles => ["Admin"];

        public class UpdateFloorCommandHandler : IRequestHandler<UpdateFloorCommand, UpdateFloorResponse>
        {
            private readonly IFloorRepository _floorRepository;
            private readonly IMapper _mapper;

            public UpdateFloorCommandHandler(IFloorRepository floorRepository, IMapper mapper)
            {
                _floorRepository = floorRepository;
                _mapper = mapper;
            }

            public async Task<UpdateFloorResponse> Handle(UpdateFloorCommand request, CancellationToken cancellationToken)
            {
                Floor? floor = await _floorRepository.GetAsync(p => p.Id == request.Id);
                if (floor is null)
                    throw new BusinessException("Böyle bir veri bulunamadı.");

                Floor? floorWithSameNo = await _floorRepository.GetAsync(p => p.No == request.No);
                if (floorWithSameNo is not null)
                {
                    throw new BusinessException("Kat No daha önceden sisteme kaydedilmiş");
                }

                Floor mappedFloor = _mapper.Map<Floor>(request);

                await _floorRepository.UpdateAsync(mappedFloor);

                UpdateFloorResponse response = _mapper.Map<UpdateFloorResponse>(mappedFloor);

                return response;
            }
        }
    }
}
