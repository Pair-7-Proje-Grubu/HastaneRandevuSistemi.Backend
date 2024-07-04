using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Commands.Create
{
    public class CreateFeedbackCommand : IRequest<CreateFeedbackResponse>
    {
        public string UserMail { get; set; }

        public string UserFeedback { get; set; }
    }

    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, CreateFeedbackResponse>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public CreateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public async Task SendFeedbackRequestEmailAsync(string userEmail, string userFeedback)
        {
            // iletisim-hrs
            var clientUser = new SendGridClient("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");
            var fromUser = new EmailAddress("iletisim-hrs@ahmetyuksel.com");
            var subjectUser = "HRS Geri Bildirim Talebi";
            var toUser = new EmailAddress("iletisim-hrs@ahmetyuksel.com");
            var plainTextContentUser = $"Kullanıcı: {userEmail}\n\nGeri Bildirim: {userFeedback}";
            var htmlContentUser = $"Kullanıcı: <strong><a href='mailto:{userEmail}' style='text-decoration:none'>{userEmail}</a></strong><br/><br/>Geri Bildirim: {userFeedback}";
            var msgUser = MailHelper.CreateSingleEmail(fromUser, toUser, subjectUser, plainTextContentUser, htmlContentUser);
            var responseUser = await clientUser.SendEmailAsync(msgUser);

            // noreply-hrs
            var clientHRS = new SendGridClient("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");
            var fromHRS = new EmailAddress($"noreply-hrs@ahmetyuksel.com");
            var subjectHRS = "HRS İçin Geri Bildirim";
            var toHRS = new EmailAddress(userEmail);

            var plainTextContentHRS = $"Sayın: {userEmail},\n\nGeri bildiriminiz başarıyla gönderildi.\n\nSistemimizi iyileştirmeye olan katkınız için teşekkür eder, iyi günler dileriz.\n\nSevgiler,\n\nHRS Hastane Randevu Sistemi\n\nLütfen bu e-postayı yanıtlamayınız.\n\n© Telif Hakkı 2024 HRS Hastane Randevu Sistemi - Tüm hakları saklıdır.";

            var htmlContentHRS = $"<strong>Sayın: {userEmail},</strong><br/><br/>Geri bildiriminiz başarıyla gönderildi.<br/><br/>Sistemimizi iyileştirmeye olan katkınız için teşekkür eder, iyi günler dileriz.<br/><br/>Sevgiler,<br/><br/>HRS Hastane Randevu Sistemi<br/><br/><hr/><br/>Lütfen bu e-postayı yanıtlamayınız.<br/><br/>© Telif Hakkı 2024 HRS Hastane Randevu Sistemi - Tüm hakları saklıdır.";

            var msgHRS = MailHelper.CreateSingleEmail(fromHRS, toHRS, subjectHRS, plainTextContentHRS, htmlContentHRS);
            var responseHRS = await clientHRS.SendEmailAsync(msgHRS);
        }

        public async Task<CreateFeedbackResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            Feedback feedback = _mapper.Map<Feedback>(request);

            await _feedbackRepository.AddAsync(feedback);

            await SendFeedbackRequestEmailAsync(feedback.UserMail, feedback.UserFeedback);

            return new CreateFeedbackResponse() 
            { 
                Id = feedback.Id, 
                UserMail = feedback.UserMail, 
                UserFeedback = feedback.UserFeedback,
            };
        }
    }
}
