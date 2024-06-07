using Application.Repositories;
using AutoMapper;
using Core.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<CreateDoctorResponse>, ISecuredRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public int TitleId { get; set; }
        public int ClinicId { get; set; }
        public int OfficeLocationId { get; set; }

        public string[] RequiredRoles => ["Doctor.Add"];

        public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, CreateDoctorResponse>
        {

            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;

            public CreateDoctorCommandHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }

            public async Task<CreateDoctorResponse> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
            {
                Doctor doctor = _mapper.Map<Doctor>(request);
                await _doctorRepository.AddAsync(doctor);

                return new CreateDoctorResponse();
            }
        }

    }
}
