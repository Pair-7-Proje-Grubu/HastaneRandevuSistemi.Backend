using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rooms.Commands.Update
{
    public class UpdateRoomCommand : IRequest<UpdateRoomResponse>
    {
        public int Id { get; set; }

        public string No { get; set; }

        public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, UpdateRoomResponse>, ISecuredRequest
        {
            private readonly IRoomRepository _roomRepository;
            private readonly IMapper _mapper;

            public string[] RequiredRoles => ["Admin"];

            public UpdateRoomCommandHandler(IRoomRepository roomRepository, IMapper mapper)
            {
                _roomRepository = roomRepository;
                _mapper = mapper;
            }

            public async Task<UpdateRoomResponse> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
            {
                Room? room = await _roomRepository.GetAsync(i => i.Id == request.Id);
                if (room is null)
                    throw new BusinessException("Böyle bir veri bulunamadı.");

                Room? roomWithSameNo = await _roomRepository.GetAsync(p => p.No == request.No);
                if (roomWithSameNo is not null)
                    throw new BusinessException("Aynı No da 2. kayıt eklenemez.");

                Room mappedRoom = _mapper.Map<Room>(request);

                await _roomRepository.UpdateAsync(mappedRoom);
                
                UpdateRoomResponse response = _mapper.Map<UpdateRoomResponse>(mappedRoom);

                return response;
            }
        }
    }
}
