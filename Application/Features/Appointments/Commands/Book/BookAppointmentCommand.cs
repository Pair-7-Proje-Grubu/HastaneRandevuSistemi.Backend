using Application.Features.Appointments.Rules;
using Application.Features.Doctors.Rules;
using Application.Features.Users.Rules;
using Application.Repositories;
using Application.Services.EmailService;
using AutoMapper;
using Core.Utilities.Extensions;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Application.Features.Appointments.Commands.Book
{
    public class BookAppointmentCommand : IRequest<BookAppointmentResponse>/*, ISecuredRequest*/
    {
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }

        //public string[] RequiredRoles => ["Patient"];

        public class BookAppointmentCommandHandler : IRequestHandler<BookAppointmentCommand, BookAppointmentResponse>
        {
            IMapper _mapper;
            IHttpContextAccessor _httpContextAccessor;
            IAppointmentRepository _appointmentRepository;
            AppointmentBusinessRules _appointmentBusinessRules;
            DoctorBusinessRules _doctorBusinessRules;
            UserBusinessRules _userBusinessRules;

            private readonly IEmailService _emailService;

            public BookAppointmentCommandHandler(IMapper mapper, IAppointmentRepository appointmentRepository, IHttpContextAccessor httpContextAccessor, AppointmentBusinessRules appointmentBusinessRules, DoctorBusinessRules doctorBusinessRules, UserBusinessRules userBusinessRules, IEmailService emailService)
            {
                _mapper = mapper;
                _appointmentRepository = appointmentRepository;
                _httpContextAccessor = httpContextAccessor;
                _appointmentBusinessRules = appointmentBusinessRules;
                _doctorBusinessRules = doctorBusinessRules;
                _userBusinessRules = userBusinessRules;
                _emailService = emailService;
            }

            public async Task<BookAppointmentResponse> Handle(BookAppointmentCommand request, CancellationToken cancellationToken)
            {
                int userId = _httpContextAccessor.HttpContext!.User.GetUserId();
                string userEmail = _httpContextAccessor.HttpContext.User.GetUserEmail()!;

                await _userBusinessRules.UserIdShouldExistWhenSelected(userId);
                await _userBusinessRules.UserEmailShouldExistWhenSelected(userEmail);
                await _doctorBusinessRules.DoctorIdShouldExistWhenSelected(request.DoctorId);
                await _appointmentBusinessRules.AppointmentCanNotDuplicatedWhenBooked(userId, request.DoctorId,request.DateTime);
                await _appointmentBusinessRules.AppointmentTimeShouldBeValidWhenBooked(request.DoctorId, request.DateTime);



                Appointment appointment = _mapper.Map<Appointment>(request);
                appointment.PatientId = userId;
                appointment.Status = AppointmentStatus.Scheduled;

                await _appointmentRepository.AddAsync(appointment);

               
                appointment = await _appointmentRepository.GetAsync(a => a.Id == appointment.Id,
                    include: source => source
                    .Include(a => a.Doctor)
                        .ThenInclude(d => d.Clinic)
                    .Include(a => a.Doctor)
                        .ThenInclude(d => d.Title)
                    .Include(a => a.Doctor)
                        .ThenInclude(d => d.User)
                    .Include(a => a.Doctor)
                        .ThenInclude(d => d.OfficeLocation)
                        .ThenInclude(u => u.Block)
                    .Include(a => a.Doctor)
                        .ThenInclude(d => d.OfficeLocation)
                        .ThenInclude(u => u.Floor)
                    .Include(a => a.Doctor)
                        .ThenInclude(d => d.OfficeLocation)
                        .ThenInclude(u => u.Room)
                    .Include(a => a.Patient)
                    );

                await _emailService.SendAppointmentInformationEmailAsync(userEmail, appointment);

                BookAppointmentResponse response = _mapper.Map<BookAppointmentResponse>(appointment);

                return response;    
            }
        }
    }
}