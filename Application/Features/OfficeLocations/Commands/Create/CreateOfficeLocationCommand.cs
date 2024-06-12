using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OfficeLocations.Commands.Create
{
    public class CreateOfficeLocationCommand : IRequest<CreateOfficeLocationResponse>
    {
        public int BlockId { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }
        public class CreateOfficeLocationCommandHandler : IRequestHandler<CreateOfficeLocationCommand, CreateOfficeLocationResponse>
        {
            private readonly IOfficeLocationRepository _officeLocationRepository;
            private readonly IMapper _mapper;
            public CreateOfficeLocationCommandHandler(IOfficeLocationRepository officeLocationRepository, IMapper mapper)
            {
                _officeLocationRepository = officeLocationRepository;
                _mapper = mapper;
            }
            public async Task<CreateOfficeLocationResponse> Handle(CreateOfficeLocationCommand request, CancellationToken cancellationToken)
            {
                OfficeLocation officeLocation = _mapper.Map<OfficeLocation>(request);
                await _officeLocationRepository.AddAsync(officeLocation);

                CreateOfficeLocationResponse response = _mapper.Map<CreateOfficeLocationResponse>(officeLocation);
                return response;
            }
        }
    }
}
