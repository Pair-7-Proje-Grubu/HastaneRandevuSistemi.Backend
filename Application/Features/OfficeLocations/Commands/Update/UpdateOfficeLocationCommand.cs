using Application.Features.Doctors.Commands.UpdateDoctor;
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

namespace Application.Features.OfficeLocations.Commands.Update
{
    public class UpdateOfficeLocationCommand : IRequest<UpdateOfficeLocationResponse>, ISecuredRequest
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }

        public string[] RequiredRoles => ["Admin"];

        public class UpdateOfficeLocationCommandHandler : IRequestHandler<UpdateOfficeLocationCommand, UpdateOfficeLocationResponse>
        {
            private readonly IOfficeLocationRepository _officeLocationRepository;
            private readonly IMapper _mapper;

            public UpdateOfficeLocationCommandHandler(IOfficeLocationRepository officeLocationRepository, IMapper mapper)
            {
                _officeLocationRepository = officeLocationRepository;
                _mapper = mapper;
            }

            public async Task<UpdateOfficeLocationResponse> Handle(UpdateOfficeLocationCommand request, CancellationToken cancellationToken)
            {
                bool exists = await _officeLocationRepository.ExistsAsync(request.BlockId, request.FloorId, request.RoomId);
                if (exists)
                {
                    throw new BusinessException("Ofis konumu zaten mevcut.");
                }
                OfficeLocation officeLocation = _mapper.Map<OfficeLocation>(request);

                await _officeLocationRepository.UpdateAsync(officeLocation);

                UpdateOfficeLocationResponse response = _mapper.Map<UpdateOfficeLocationResponse>(officeLocation);

                return response;
            }
        }
    }
}
