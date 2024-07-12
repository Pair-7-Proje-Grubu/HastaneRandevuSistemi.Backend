using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.Update.ChangePassword
{
    public class ChangePasswordCommand : IRequest<ChangePasswordResponse>
    {
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;

            public ChangePasswordCommandHandler(IPatientRepository patientRepository, IMapper mapper)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
            }

            public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(p => p.Email == request.Email);
                if (patient is null)
                {
                    throw new BusinessException("Kullanıcı bulunamadı.");
                }

                bool isPasswordMatch = HashingHelper.VerifyPasswordHash(request.CurrentPassword, patient.PasswordSalt, patient.PasswordHash);
                if (!isPasswordMatch)
                {
                    throw new BusinessException("Mevcut şifre yanlış.");
                }

                bool isNewPasswordSameAsCurrent = HashingHelper.VerifyPasswordHash(request.NewPassword, patient.PasswordSalt, patient.PasswordHash);
                if (isNewPasswordSameAsCurrent)
                {
                    throw new BusinessException("Yeni şifre mevcut şifre ile aynı olamaz.");
                }

                byte[] passwordSalt, passwordHash;
                HashingHelper.CreatePasswordHash(request.NewPassword, out passwordSalt, out passwordHash);
                patient.PasswordSalt = passwordSalt;
                patient.PasswordHash = passwordHash;

                await _patientRepository.UpdateAsync(patient);

                ChangePasswordResponse response = _mapper.Map<ChangePasswordResponse>(patient);
                response.IsSuccess = true;
                response.Message = "Parola başarıyla güncellendi.";

                return response;
            }
        }
    }
}