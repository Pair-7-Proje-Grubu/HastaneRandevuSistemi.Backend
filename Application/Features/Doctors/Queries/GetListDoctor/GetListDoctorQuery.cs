using Application.Features.Doctors.Commands.CreateDoctor;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Queries.GetListDoctor
{
    public class GetListDoctorQuery : IRequest<GetListDoctorResponse>
    {


        public class GetListDoctorQueryHandler : IRequestHandler<GetListDoctorQuery, GetListDoctorResponse>
        {

            private readonly IDoctorRepository _doctorRepository;

            public GetListDoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
            }


            public async Task<GetListDoctorResponse> Handle(GetListDoctorQuery request, CancellationToken cancellationToken)
            {
                GetListDoctorResponse response = new GetListDoctorResponse();
                response.Doctors = await _doctorRepository.GetListAsync();
                return response;
            }
        }
    }
}
