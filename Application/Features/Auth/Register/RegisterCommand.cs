using Application.Features.Appointments.Commands.Book;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities;
using Domain.Entities;
using FluentValidation;
using MediatR;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Register
{
    public class RegisterCommand : IRequest<RegisterResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
        {
            private readonly IMapper _mapper;
            private readonly IPatientRepository _patientRepository;

            public RegisterCommandHandler(IMapper mapper, IPatientRepository patientRepository)
            {
                _mapper = mapper;
                _patientRepository = patientRepository;
            }

            public async Task WelcomeEmailAsync(string email, string userName)
            {
                var client = new SendGridClient("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");
                var from = new EmailAddress("noreply-hrs@ahmetyuksel.com");
                var subject = "HRS Hastane Randevu Sistemi'ne Hoşgeldiniz";
                var to = new EmailAddress(email);

                var plainTextContent = $"Merhaba {userName},\n\nHRS Hastane Randevu Sistemi'ne hoşgeldiniz.\n\nKayıt işleminiz başarıyla gerçekleşmiş olup, sistemden randevunuzu alabilirsiniz.\n\nDetaylar için websitemizi ziyaret edebilir; görüş, öneri, şikayet ve tüm sorularınız için iletisim-hrs@ahmetyuksel.com adresine e-posta gönderebilirsiniz.\n\nLütfen bu e-postayı yanıtlamayınız.\n\n© Telif Hakkı 2024 HRS Hastane Randevu Sistemi - Tüm hakları saklıdır.";
                
                var htmlContent = $"<strong>Merhaba {userName},</strong><br/><br/>HRS Hastane Randevu Sistemi'ne hoşgeldiniz.<br/><br/>Kayıt işleminiz başarıyla gerçekleşmiş olup, sistemden randevunuzu alabilirsiniz.<br/><br/>Detaylar için websitemizi ziyaret edebilir;<br/> görüş, öneri, şikayet ve tüm sorularınız için <strong><a href='mailto:iletisim-hrs@ahmetyuksel.com' style='text-decoration:none'>iletisim-hrs@ahmetyuksel.com</a></strong> adresine e-posta gönderebilirsiniz.<br/><br/><hr/><br/>Lütfen bu e-postayı yanıtlamayınız.<br/><br/>© Telif Hakkı 2024 HRS Hastane Randevu Sistemi - Tüm hakları saklıdır.";
                
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }

            public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {


                Patient? patientWithSameEmail = await _patientRepository.GetAsync(p => p.Email == request.Email);
                if (patientWithSameEmail is not null)
                {
                    throw new BusinessException("Email adresi ile daha önceden sisteme kayıt yapılmış");
                }

                Patient newPatient = _mapper.Map<Patient>(request);

                byte[] passwordSalt, passwordHash;

                HashingHelper.CreatePasswordHash(request.Password, out passwordSalt, out passwordHash);
                newPatient.PasswordSalt = passwordSalt;
                newPatient.PasswordHash = passwordHash;
                newPatient.UserOperationClaims = new List<UserOperationClaim>() {
                    new UserOperationClaim() { OperationClaimId = 1, UserId = newPatient.Id }
                };
                await _patientRepository.AddAsync(newPatient);

                await WelcomeEmailAsync(request.Email, $"{request.FirstName} {request.LastName}");

                return new RegisterResponse();
            }
        }


        

    }

    
}
