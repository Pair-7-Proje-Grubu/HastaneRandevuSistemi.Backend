using Application.Repositories;
using AutoMapper;
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
    public class UpdateFloorCommand : IRequest<UpdateFloorResponse>
    {
        public int Id { get; set; }

        public int No { get; set; }

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
                    throw new ValidationException("Böyle bir veri bulunamadı.");

                Floor mappedFloor = _mapper.Map<Floor>(request);

                await _floorRepository.UpdateAsync(mappedFloor);

                UpdateFloorResponse response = new UpdateFloorResponse();

                return response;
            }
        }
    }
}
