using Application.Features.Doctors.Commands.UpdateDoctor;
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

namespace Application.Features.Rooms.Commands.Update
{
    public class UpdateRoomCommand : IRequest<UpdateRoomResponse>
    {
        public int Id { get; set; }

        public string No { get; set; }

        public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, UpdateRoomResponse>
        {
            private readonly IRoomRepository _roomRepository;
            private readonly IMapper _mapper;

            public UpdateRoomCommandHandler(IRoomRepository roomRepository, IMapper mapper)
            {
                _roomRepository = roomRepository;
                _mapper = mapper;
            }

            public async Task<UpdateRoomResponse> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
            {
                Room? room = await _roomRepository.GetAsync(p => p.Id == request.Id);

                if (room is null)
                    throw new ValidationException("Böyle bir veri bulunamadı.");

                Room mappedRoom = _mapper.Map<Room>(request);

                await _roomRepository.UpdateAsync(mappedRoom);

                UpdateRoomResponse response = new UpdateRoomResponse();

                return response;
            }
        }
    }
}
