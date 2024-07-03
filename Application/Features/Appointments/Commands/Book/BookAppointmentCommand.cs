using Application.Repositories;
using AutoMapper;
using Core.Utilities.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commands.Book
{
    public class BookAppointmentCommand : IRequest<BookAppointmentResponse>
    {
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }

        public class BookAppointmentCommandHandler : IRequestHandler<BookAppointmentCommand, BookAppointmentResponse>
        {
            IMapper _mapper;
            IAppointmentRepository _appointmentRepository;
            IHttpContextAccessor _httpContextAccessor;
            public BookAppointmentCommandHandler(IMapper mapper, IAppointmentRepository appointmentRepository, IHttpContextAccessor httpContextAccessor)
            {
                _mapper = mapper;
                _appointmentRepository = appointmentRepository;
                _httpContextAccessor = httpContextAccessor;
            }
            public async Task<BookAppointmentResponse> Handle(BookAppointmentCommand request, CancellationToken cancellationToken)
            {
                int userId = _httpContextAccessor.HttpContext.User.GetUserId();

                Appointment appointment = _mapper.Map<Appointment>(request);
                appointment.PatientId = userId;
                appointment.isCancelStatus = CancelStatus.NoCancel;
                await _appointmentRepository.AddAsync(appointment);
                BookAppointmentResponse response = _mapper.Map<BookAppointmentResponse>(appointment);

                return response;    
            }
        }
    }
}
