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

            private readonly IAppointmentRepository _appointmentRepository;

            public GetListDoctorQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
            }


            public async Task<GetListDoctorResponse> Handle(GetListDoctorQuery request, CancellationToken cancellationToken)
            {

                GetListDoctorResponse response = new GetListDoctorResponse();
                await _appointmentRepository.GetListAsync();

                return response;
            }
        }
    }
}
