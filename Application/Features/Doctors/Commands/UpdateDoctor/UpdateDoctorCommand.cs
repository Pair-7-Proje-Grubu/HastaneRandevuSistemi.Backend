using Application.Features.Doctors.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommand :  IRequest<UpdateDoctorResponse>, ISecuredRequest
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int TitleId { get; set; }

        public string[] RequiredRoles => ["Admin"];

        public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, UpdateDoctorResponse>
        {

            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;
            private readonly DoctorBusinessRules _doctorBusinessRules;

            public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper, DoctorBusinessRules doctorBusinessRules)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
                _doctorBusinessRules = doctorBusinessRules;
            }

            public async Task<UpdateDoctorResponse> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
            {
                Doctor? doctor = await _doctorRepository.GetAsync(d => d.Id == request.Id);

                await _doctorBusinessRules.DoctorIdShouldExistWhenSelected(request.Id);

                _mapper.Map(request, doctor);

                await _doctorRepository.UpdateAsync(doctor);

                UpdateDoctorResponse response = new();
                return response;
            }
        }


    }
}
