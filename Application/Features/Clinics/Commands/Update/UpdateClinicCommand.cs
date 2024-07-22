using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clinics.Commands.Update
{
    public class UpdateClinicCommand : IRequest<UpdateClinicResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public class UpdateClinicCommandHandler : IRequestHandler<UpdateClinicCommand, UpdateClinicResponse>
        {
            private readonly IClinicRepository _clinicRepository;
            private readonly IMapper _mapper;

            public UpdateClinicCommandHandler(IClinicRepository clinicRepository, IMapper mapper)
            {
                _clinicRepository = clinicRepository;
                _mapper = mapper;
            }

            public async Task<UpdateClinicResponse> Handle(UpdateClinicCommand request, CancellationToken cancellationToken)
            {
                Clinic clinic = _mapper.Map<Clinic>(request);
                await _clinicRepository.UpdateAsync(clinic);
                UpdateClinicResponse response = _mapper.Map<UpdateClinicResponse>(clinic);
                return response;
            }
        }
    }

}
