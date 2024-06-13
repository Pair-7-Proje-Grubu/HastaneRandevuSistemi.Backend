using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clinics.Commands.Create
{
    public class CreateClinicCommand : IRequest<CreateClinicResponse>, ISecuredRequest
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int AppointmentDuration { get; set; }
        public string[] RequiredRoles => ["Admin"];  // ???


        public class CreateClinicCommandHandler : IRequestHandler<CreateClinicCommand, CreateClinicResponse>
        {
            private readonly IClinicRepository _clinicRepository;
            private readonly IMapper _mapper;

            public CreateClinicCommandHandler(IClinicRepository clinicRepository, IMapper mapper)

            {
                _clinicRepository = clinicRepository;
                _mapper = mapper;
            }

            public async Task<CreateClinicResponse> Handle(CreateClinicCommand request, CancellationToken cancellationToken)
            {
                Clinic clinic = _mapper.Map<Clinic>(request);
                await _clinicRepository.AddAsync(clinic);
                return new CreateClinicResponse() { Id = clinic.Id, Name = clinic.Name, PhoneNumber = clinic.PhoneNumber, AppointmentDuration= clinic.AppointmentDuration };

            }

        }
    }
}
