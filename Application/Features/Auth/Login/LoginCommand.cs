using Application.Repositories;
using Core.Entities;
using Core.Utilities;
using Core.Utilities.JWT;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auth.Login
{
    public class LoginCommand : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public LoginCommandHandler(IPatientRepository patientRepository, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _patientRepository = patientRepository;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(p => p.Email == request.Email);

                if (patient is null)
                {
                    throw new Exception("Giriş Başarısız");
                }

                bool isPasswordMatch = HashingHelper.VerifyPasswordHash(request.Password, patient.PasswordSalt, patient.PasswordHash);

                if(!isPasswordMatch)
                {
                    throw new Exception("Giriş Başarısız");
                }

                List<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository
                    .GetListAsync(i => i.UserId == patient.Id, include: i => i.Include(i => i.OperationClaim));

                return _tokenHelper.CreateToken(patient, userOperationClaims.Select(i => (BaseOperationClaim)i.OperationClaim).ToList());
            }
        }
    }
}
