using MediatR;
using AutoMapper;
using Application.Repositories;
using Domain.Entities;
using SendGrid.Helpers.Errors.Model;

namespace Application.Features.Users.Queries.GetPhoneNumber
{
    public class GetPhoneNumberQuery : IRequest<GetPhoneNumberResponse>
    {
        public string Email { get; set; }

        public class GetPhoneNumberQueryHandler : IRequestHandler<GetPhoneNumberQuery, GetPhoneNumberResponse>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;

            public GetPhoneNumberQueryHandler(IPatientRepository patientRepository, IMapper mapper)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
            }

            public async Task<GetPhoneNumberResponse> Handle(GetPhoneNumberQuery request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(p => p.Email == request.Email);
                if (patient == null)
                {
                    throw new NotFoundException("Bu e-posta adresine sahip bir kullanıcı bulunamadı.");
                }

                GetPhoneNumberResponse response = _mapper.Map<GetPhoneNumberResponse>(patient);
                return response;
            }
        }
    }
}