using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.Update
{
    public class ChangePasswordCommand : IRequest<ChangePasswordResponse>
    {
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
        {
            private readonly IPatientRepository _patientRepository;

            public ChangePasswordCommandHandler(IPatientRepository patientRepository)
            {
                _patientRepository = patientRepository;
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

                // Yeni şifre eski şifre ile aynı mı kontrol et
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

                return new ChangePasswordResponse { IsSuccess = true, Message = "Şifre başarıyla güncellendi." };
            }
        }
    }
}
