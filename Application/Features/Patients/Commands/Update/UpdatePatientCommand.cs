using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patients.Commands.Update
{
    public class UpdatePatientCommand : IRequest<UpdatePatientResponse>, ISecuredRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public BloodType? BloodType { get; set; }
        public string? EmergencyContact { get; set; }

        public string[] RequiredRoles => ["Admin"];

        public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, UpdatePatientResponse>
        {
            private readonly IMapper _mapper;
            private readonly IPatientRepository _patientRepository;
            private readonly UserBusinessRules _userBusinessRules;

            public UpdatePatientCommandHandler(IMapper mapper, IPatientRepository patientRepository, UserBusinessRules userBusinessRules)
            {
                _mapper = mapper;
                _patientRepository = patientRepository;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UpdatePatientResponse> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(p => p.Id == request.Id);

                await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);

                _mapper.Map(request, patient);

                await _patientRepository.UpdateAsync(patient);

                UpdatePatientResponse response = new UpdatePatientResponse();

                return response;
            }
        }
    }
}
