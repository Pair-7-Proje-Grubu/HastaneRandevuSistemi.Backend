
using Application.Features.Clinics.Queries.GetByIdClinic;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Application.Features.Clinics.Queries.GetByIdClinic
{
    public class GetByIdClinicQuery : IRequest<GetByIdClinicResponse>
    {
        public int Id { get; set; }

        public class GetByIdClinicQueryHandler : IRequestHandler<GetByIdClinicQuery, GetByIdClinicResponse>
        {

            private IClinicRepository _clinicRepository;
            private IMapper _mapper;

            public GetByIdClinicQueryHandler(IClinicRepository clinicRepository, IMapper mapper)
            {
                _clinicRepository = clinicRepository;
                _mapper = mapper;
            }



            public async Task<GetByIdClinicResponse> Handle(GetByIdClinicQuery request, CancellationToken cancellationToken)

            {
                Clinic? clinic = await _clinicRepository.GetAsync(x => x.Id == request.Id);

                GetByIdClinicResponse response = new GetByIdClinicResponse();
                response.Clinic = clinic;
                return response;

            }
        }
    }


}
