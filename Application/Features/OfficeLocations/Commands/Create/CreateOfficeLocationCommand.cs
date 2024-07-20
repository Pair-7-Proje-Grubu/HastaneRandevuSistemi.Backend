using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OfficeLocations.Commands.Create
{
    public class CreateOfficeLocationCommand : IRequest<CreateOfficeLocationResponse>, ISecuredRequest
    {
        public int BlockId { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }

        public string[] RequiredRoles => ["Admin"];
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
                bool exists = await _officeLocationRepository.ExistsAsync(request.BlockId, request.FloorId, request.RoomId);
                if (exists)
                {
                    throw new BusinessException("Ofis konumu zaten mevcut.");
                }
                OfficeLocation officeLocation = _mapper.Map<OfficeLocation>(request);
                await _officeLocationRepository.AddAsync(officeLocation);

                CreateOfficeLocationResponse response = _mapper.Map<CreateOfficeLocationResponse>(officeLocation);
                return response;
            }
        }
    }
}
