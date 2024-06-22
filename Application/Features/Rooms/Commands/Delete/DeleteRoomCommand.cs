using Application.Features.Reports.Commands.Delete;
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

namespace Application.Features.Rooms.Commands.Delete
{
    public class DeleteRoomCommand : IRequest , ISecuredRequest
    {
        public int Id { get; set; }

        public string[] RequiredRoles => ["Admin"];

        public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
        {
            private IRoomRepository _roomRepository;
            private readonly IMapper _mapper;

            public DeleteRoomCommandHandler(IRoomRepository roomRepository, IMapper mapper)
            {
                _roomRepository = roomRepository;
                _mapper = mapper;
            }

            public async Task Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
            {
                Room? room = await _roomRepository.GetAsync(i => i.Id == request.Id);
                if (room is null)
                    throw new BusinessException("Böyle bir veri bulunamadı.");

                await _roomRepository.DeleteAsync(room);
            }
        }
    }
}
