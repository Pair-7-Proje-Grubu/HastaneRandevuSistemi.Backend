using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commands.Create
{
    public class CreateAppointmentCommand : IRequest<CreateAppointmentResponse>
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        public CancelStatus isCancelStatus { get; set; }

        public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, CreateAppointmentResponse>
        {
            IMapper _mapper;
            IAppointmentRepository _appointmentRepository;

            public CreateAppointmentCommandHandler(IMapper mapper, IAppointmentRepository appointmentRepository)
            {
                _mapper = mapper;
                _appointmentRepository = appointmentRepository;
            }
            public async Task<CreateAppointmentResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
            {

                Appointment appointment = _mapper.Map<Appointment>(request);

                if(appointment.isCancelStatus is CancelStatus.NoCancel)
                {
                    await _appointmentRepository.AddAsync(appointment);
                }

                CreateAppointmentResponse response = _mapper.Map<CreateAppointmentResponse>(appointment);

                return response;    
            }
        }
    }
}
