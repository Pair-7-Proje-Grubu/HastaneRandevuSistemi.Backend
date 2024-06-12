using Application.Features.Reports.Commands.Delete;
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

namespace Application.Features.Floors.Commands.Delete
{
    public class DeleteFloorCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteFloorCommandHandler : IRequestHandler<DeleteFloorCommand>
        {
            private IFloorRepository _floorRepository;
            private readonly IMapper _mapper;

            public DeleteFloorCommandHandler(IFloorRepository floorRepository, IMapper mapper)
            {
                _floorRepository = floorRepository;
                _mapper = mapper;
            }

            public async Task Handle(DeleteFloorCommand request, CancellationToken cancellationToken)
            {
                Floor? floor = await _floorRepository.GetAsync(i => i.Id == request.Id);
                if (floor is null)
                    throw new ValidationException("Böyle bir veri bulunamadı.");

                await _floorRepository.DeleteAsync(floor);
            }
        }
    }
}
