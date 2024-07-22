using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<CreateDoctorResponse>, ISecuredRequest
    {
        public string Email { get; set; }
        public int TitleId { get; set; }
        public int ClinicId { get; set; }
        public int OfficeLocationId { get; set; }

        public string[] RequiredRoles => ["Admin"];

        public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, CreateDoctorResponse>
        {

            private readonly IPatientRepository _userRepository;
            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;

            public CreateDoctorCommandHandler(IPatientRepository userRepository, IDoctorRepository doctorRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }

            public async Task<CreateDoctorResponse> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
            {
                // Email kontrolü ve kullanıcıyı bulma
                User? user = await _userRepository.GetAsync(p => p.Email == request.Email);
                if (user == null)
                {
                    throw new BusinessException("Email adresi ile kayıtlı kullanıcı bulunamadı");
                }

                // Doctor entity'sini oluşturma ve kaydetme
                Doctor doctor = new()
                {
                    Id = user.Id, // User ID'si Doctor ID olarak kullanılır
                    TitleId = request.TitleId,
                    ClinicId = request.ClinicId,
                    OfficeLocationId = request.OfficeLocationId,
                    
                    // Diğer gerekli alanlar
                };   // Doctor entity'sini oluşturma ve kaydetme
               
                await _doctorRepository.AddAsync(doctor);

                CreateDoctorResponse response = _mapper.Map<CreateDoctorResponse>(doctor);

                return response;
            }
        }

    }
}
