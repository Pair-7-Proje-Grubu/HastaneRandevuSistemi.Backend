using Application.Features.Doctors.Commands.CreateDoctor;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Queries.GetByIdDoctor
{
    public class GetByIdDoctorQuery : IRequest<GetByIdDoctorResponse>
    {
        public int Id { get; set; } 

        public class GetByIdDoctorQueryHandler : IRequestHandler<GetByIdDoctorQuery, GetByIdDoctorResponse>
        {

            private readonly IDoctorRepository _doctorRepository;

            public GetByIdDoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
            }


            public async Task<GetByIdDoctorResponse> Handle(GetByIdDoctorQuery request, CancellationToken cancellationToken)
            {
                
                Doctor? doctor = await _doctorRepository.GetAsync(x=> x.Id == request.Id);

                GetByIdDoctorResponse response = new GetByIdDoctorResponse();
                response.Doctor = doctor;

                return response;
            }
        }
    }
}
