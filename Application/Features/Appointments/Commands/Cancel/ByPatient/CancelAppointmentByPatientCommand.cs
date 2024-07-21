using Application.Features.Appointments.Commands.Book;
using Application.Features.Appointments.Rules;
using Application.Features.Doctors.Rules;
using Application.Features.Users.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Mail;
using SendGrid;
using Core.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;
using Core.Application.Pipelines.Authorization;
using Application.Services.EmailService;

namespace Application.Features.Appointments.Commands.Cancel.ByPatient
{
    public class CancelAppointmentByPatientCommand : IRequest<CancelAppointmentByPatientResponse>/*, ISecuredRequest*/
    {
        public int Id { get; set; }

        //public string[] RequiredRoles => ["Patient"];

        public class CancelAppointmentByPatientCommandHandler : IRequestHandler<CancelAppointmentByPatientCommand, CancelAppointmentByPatientResponse>
        {
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly AppointmentBusinessRules _appointmentBusinessRules;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IEmailService _emailService;
            public CancelAppointmentByPatientCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IAppointmentRepository appointmentRepository, AppointmentBusinessRules appointmentBusinessRules, UserBusinessRules userBusinessRules, IEmailService emailService)
            {
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
                _appointmentRepository = appointmentRepository;
                _appointmentBusinessRules = appointmentBusinessRules;
                _userBusinessRules = userBusinessRules;
                _emailService = emailService;
            }

            public async Task<CancelAppointmentByPatientResponse> Handle(CancelAppointmentByPatientCommand request, CancellationToken cancellationToken)
            {
                int userId = _httpContextAccessor.HttpContext!.User.GetUserId();
                string userEmail = _httpContextAccessor.HttpContext.User.GetUserEmail()!;

                await _userBusinessRules.UserIdShouldExistWhenSelected(userId);
                await _userBusinessRules.UserEmailShouldExistWhenSelected(userEmail);

                Appointment? appointment = await _appointmentRepository.GetAsync(
                    a => a.Id == request.Id,
                    include: source => source
                    .Include(a => a.Doctor)
                        .ThenInclude(d => d.Clinic)
                    .Include(a => a.Doctor)
                        .ThenInclude(d => d.Title)
                    .Include(a => a.Doctor)
                        .ThenInclude(d => d.User)
                    .Include(a => a.Patient)
                    );

                await _appointmentBusinessRules.AppointmentShouldExistWhenSelected(appointment);
                await _appointmentBusinessRules.UserShouldBePatientWhenCancelled(appointment!, userId);
                await _appointmentBusinessRules.AppointmentShouldNoCancelWhenCancelled(appointment!);

                appointment!.Status = AppointmentStatus.CancelByPatient;

                await _appointmentRepository.UpdateAsync(appointment);

                await _emailService.SendCancelAppointmentByPatientInformationEmailAsync(appointment.Doctor.User.Email, appointment);

                CancelAppointmentByPatientResponse response = _mapper.Map<CancelAppointmentByPatientResponse>(appointment);

                return response;
            }
        }
    }
}
