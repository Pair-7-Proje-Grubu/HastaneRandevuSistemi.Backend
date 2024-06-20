using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rooms.Commands.Create
{
    public class CreateRoomCommand: IRequest<CreateRoomResponse>, ISecuredRequest
    {
        public string No { get; set; }

        public string[] RequiredRoles => ["Admin"];

        public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, CreateRoomResponse>
        {
            private readonly IRoomRepository _roomRepository;
            private readonly IMapper _mapper;
            public CreateRoomCommandHandler(IRoomRepository roomRepository, IMapper mapper)
            {
                _roomRepository = roomRepository;
                _mapper = mapper;
            }
            public async Task<CreateRoomResponse> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
            {
                Room? roomWithSameNo = await _roomRepository.GetAsync(p => p.No == request.No);
                if (roomWithSameNo is not null)
                    throw new BusinessException("Aynı No da 2. kayıt eklenemez.");

                Room room = _mapper.Map<Room>(request);
                await _roomRepository.AddAsync(room);

                CreateRoomResponse response = _mapper.Map<CreateRoomResponse>(room);
                return response;
            }
        }
    }
}
