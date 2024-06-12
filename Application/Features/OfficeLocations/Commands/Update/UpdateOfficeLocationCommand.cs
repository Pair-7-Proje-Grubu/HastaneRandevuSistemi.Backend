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

namespace Application.Features.OfficeLocations.Commands.Update
{
    public class UpdateOfficeLocationCommand : IRequest<UpdateOfficeLocationResponse>
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }

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
                OfficeLocation? officeLocation = await _officeLocationRepository.GetAsync(p => p.Id == request.Id);

                if (officeLocation is null)
                    throw new ValidationException("Böyle bir veri bulunamadı.");

                OfficeLocation mappedOfficeLocation = _mapper.Map<OfficeLocation>(request);

                await _officeLocationRepository.UpdateAsync(mappedOfficeLocation);

                UpdateOfficeLocationResponse response = new UpdateOfficeLocationResponse();

                return response;
            }
        }
    }
}
