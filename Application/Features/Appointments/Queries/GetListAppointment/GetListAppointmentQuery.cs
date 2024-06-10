using Application.Features.Doctors.Queries.GetListDoctor;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetListAppointment
{

    public class GetListAppointmentQuery : IRequest<GetListAppointmentResponse>
    {
        public class GetListAppointmentQueryHandler : IRequestHandler<GetListAppointmentQuery, GetListAppointmentResponse>
        {

            private readonly IDoctorRepository _doctorRepository;

            public GetListAppointmentQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
            }


            public async Task<GetListAppointmentResponse> Handle(GetListAppointmentQuery request, CancellationToken cancellationToken)
            { 
                GetListDoctorResponse response = new GetListDoctorResponse();
                await _doctorRepository.GetListAsync();

                return null;
            }
        }
    }
}
