using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.Update
{
    public class ChangePhoneNumberCommand : IRequest<ChangePhoneNumberResponse>
    {
        public string Email { get; set; }
        public string NewPhone { get; set; }

        public class ChangePhoneNumberCommandHandler : IRequestHandler<ChangePhoneNumberCommand, ChangePhoneNumberResponse>
        {
            private readonly IPatientRepository _patientRepository;
            private readonly IMapper _mapper;

            public ChangePhoneNumberCommandHandler(IPatientRepository patientRepository, IMapper mapper)
            {
                _patientRepository = patientRepository;
                _mapper = mapper;
            }

            public async Task<ChangePhoneNumberResponse> Handle(ChangePhoneNumberCommand request, CancellationToken cancellationToken)
            {
                Patient? patient = await _patientRepository.GetAsync(p => p.Email == request.Email);
                if (patient == null)
                    throw new BusinessException("Hasta bulunamadı");

                patient.Phone = request.NewPhone;
                await _patientRepository.UpdateAsync(patient);

                ChangePhoneNumberResponse response = _mapper.Map<ChangePhoneNumberResponse>(patient);
                return response;
            }
        }
    }
}