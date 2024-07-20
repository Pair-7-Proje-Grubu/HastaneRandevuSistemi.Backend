using Application.Features.Appointments.Rules;
using Application.Features.Doctors.Rules;
using Application.Features.Users.Rules;
using Application.Features.WorkingTimes.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Utilities.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public BookAppointmentCommandHandler(IMapper mapper, IAppointmentRepository appointmentRepository, IHttpContextAccessor httpContextAccessor, AppointmentBusinessRules appointmentBusinessRules, DoctorBusinessRules doctorBusinessRules, UserBusinessRules userBusinessRules)
            {
                _mapper = mapper;
                _appointmentRepository = appointmentRepository;
                _httpContextAccessor = httpContextAccessor;
                _appointmentBusinessRules = appointmentBusinessRules;
                _doctorBusinessRules = doctorBusinessRules;
                _userBusinessRules = userBusinessRules;
            }

            public async Task AppointmentInformationEmailAsync(string email, Appointment appointment)
            {
                var client = new SendGridClient("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");
                var from = new EmailAddress("noreply-hrs@ahmetyuksel.com");
                var subject = "HRS Randevu Alma İşleminiz";
                var to = new EmailAddress(email);

                var plainTextContent = $"Sayın {appointment.Patient.FirstName + ' ' + appointment.Patient.LastName},\n\nHRS randevu alma işleminiz başarıyla gerçekleştirildi.\n\nRandevu bilgileriniz aşağıdaki gibidir:\n\nRandevu Tarihi: {appointment.DateTime},\nKlinik Adı: {appointment.Doctor.Clinic.Name}\nHekim Adı: {appointment.Doctor.Title.TitleName} {appointment.Doctor.User.FirstName} {appointment.Doctor.User.LastName},\nDoktor Ofisi: {appointment.Doctor.OfficeLocation.Block.No + " Blok, " + appointment.Doctor.OfficeLocation.Floor.No + " Kat, Oda: " + appointment.Doctor.OfficeLocation.Room.No}\n\nGörüş, öneri, şikayet ve tüm sorularınız için iletisim-hrs@ahmetyuksel.com adresine e-posta gönderebilirsiniz.\n\nLütfen bu e-postayı yanıtlamayınız.\n\n© Telif Hakkı 2024 HRS Hastane Randevu Sistemi - Tüm hakları saklıdır.";
                
                var htmlContent = $"<strong>Sayın {appointment.Patient.FirstName + ' ' + appointment.Patient.LastName},</strong><br/><br/>HRS randevu alma işleminiz başarıyla gerçekleştirildi.<br/><br/>Randevu bilgileriniz aşağıdaki gibidir:<br/><br/>Randevu Tarihi: {appointment.DateTime},<br/>Klinik Adı: {appointment.Doctor.Clinic.Name}<br/>Hekim Adı: {appointment.Doctor.Title.TitleName} {appointment.Doctor.User.FirstName} {appointment.Doctor.User.LastName},<br/>Doktor Ofisi: {appointment.Doctor.OfficeLocation.Block.No + " Blok, " + appointment.Doctor.OfficeLocation.Floor.No + " Kat, Oda: " + appointment.Doctor.OfficeLocation.Room.No}<br/><br/>Görüş, öneri, şikayet ve tüm sorularınız için <strong><a href='mailto:iletisim-hrs@ahmetyuksel.com' style='text-decoration:none'>iletisim-hrs@ahmetyuksel.com</a></strong> adresine e-posta gönderebilirsiniz.<br/><br/><hr/><br/>Lütfen bu e-postayı yanıtlamayınız.<br/><br/>© Telif Hakkı 2024 HRS Hastane Randevu Sistemi - Tüm hakları saklıdır.";
                
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
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
                appointment.isCancelStatus = CancelStatus.NoCancel;

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


                await AppointmentInformationEmailAsync(userEmail, appointment);

                BookAppointmentResponse response = _mapper.Map<BookAppointmentResponse>(appointment);

                return response;    
            }
        }
    }
}
