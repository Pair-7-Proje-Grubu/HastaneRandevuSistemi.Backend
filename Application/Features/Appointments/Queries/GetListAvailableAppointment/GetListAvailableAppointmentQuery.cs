using Application.Features.Doctors.Queries.GetListDoctor;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetListAvailableAppointment
{

    public class GetListAvailableAppointmentQuery : IRequest<GetListAvailableAppointmentResponse>
    {
        public class GetListAvailableAppointmentQueryHandler : IRequestHandler<GetListAvailableAppointmentQuery, GetListAvailableAppointmentResponse>
        {

            private readonly IDoctorRepository _doctorRepository;

            public GetListAvailableAppointmentQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
            }


            public async Task<GetListAvailableAppointmentResponse> Handle(GetListAvailableAppointmentQuery request, CancellationToken cancellationToken)
            {
                GetListDoctorResponse response = new GetListDoctorResponse();
                response.Doctors = await _doctorRepository.GetListAsync();

                return response;
            }
        }
    }
}
