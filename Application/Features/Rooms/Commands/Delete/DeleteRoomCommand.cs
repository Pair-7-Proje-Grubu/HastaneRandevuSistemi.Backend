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

namespace Application.Features.Rooms.Commands.Delete
{
    public class DeleteRoomCommand : IRequest
    {
        public int Id { get; set; }

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
                    throw new ValidationException("Böyle bir veri bulunamadı.");

                await _roomRepository.DeleteAsync(room);
            }
        }
    }
}
