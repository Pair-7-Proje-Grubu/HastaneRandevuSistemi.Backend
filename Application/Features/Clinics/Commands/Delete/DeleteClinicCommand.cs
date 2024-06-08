using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clinics.Commands.Delete
{
    public class DeleteClinicCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteClinicCommandHandler : IRequestHandler<DeleteClinicCommand>
        {
            private IClinicRepository _clinicRepository;
            private readonly IMapper _mapper;

            public DeleteClinicCommandHandler(IClinicRepository clinicRepository, IMapper mapper)
            {
                _clinicRepository = clinicRepository;
                _mapper = mapper;
            }

            public async Task Handle(DeleteClinicCommand request, CancellationToken cancellationToken)
            {
                Clinic? clinic = _mapper.Map<Clinic>(request);

                if (clinic is null)
                    throw new Exception("Böyle bir klinik bulunamadı.");

                await _clinicRepository.DeleteAsync(clinic);
            }
        }

    }
}
