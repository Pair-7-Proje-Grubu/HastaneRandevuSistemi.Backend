using Domain.Entities;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly SendGridClient _client;
        private readonly EmailAddress _fromAddress;

        private readonly SendGridClient _clientFeedbackUser;
        private readonly EmailAddress _fromAddressFeedbackUser;

        public EmailService(string sendGridApiKey, string fromEmail, string sendGridApiKeyFeedbackUser, string fromEmailFeedbackUser)
        {
            _client = new SendGridClient(sendGridApiKey);
            _fromAddress = new EmailAddress(fromEmail);

            _clientFeedbackUser = new SendGridClient(sendGridApiKeyFeedbackUser);
            _fromAddressFeedbackUser = new EmailAddress(fromEmailFeedbackUser);
        }

        public async Task SendAppointmentInformationEmailAsync(string email, Appointment appointment)
        {
            var subject = "HRS Randevu Alma İşleminiz";
            var to = new EmailAddress(email);

            var plainTextContent = $"Sayın {appointment.Patient.FirstName + ' ' + appointment.Patient.LastName},\n\nHRS randevu alma işleminiz başarıyla gerçekleştirildi.\n\nRandevu bilgileriniz aşağıdaki gibidir:\n\nRandevu Tarihi: {appointment.DateTime},\nKlinik Adı: {appointment.Doctor.Clinic.Name}\nHekim Adı: {appointment.Doctor.Title.TitleName} {appointment.Doctor.User.FirstName} {appointment.Doctor.User.LastName},\nDoktor Ofisi: {appointment.Doctor.OfficeLocation.Block.No + " Blok, " + appointment.Doctor.OfficeLocation.Floor.No + " Kat, Oda: " + appointment.Doctor.OfficeLocation.Room.No}\n\nGörüş, öneri, şikayet ve tüm sorularınız için iletisim-hrs@ahmetyuksel.com adresine e-posta gönderebilirsiniz.\n\nLütfen bu e-postayı yanıtlamayınız.\n\n© Telif Hakkı 2024 HRS Hastane Randevu Sistemi - Tüm hakları saklıdır.";

            var htmlContent = $"<strong>Sayın {appointment.Patient.FirstName + ' ' + appointment.Patient.LastName},</strong><br/><br/>HRS randevu alma işleminiz başarıyla gerçekleştirildi.<br/><br/>Randevu bilgileriniz aşağıdaki gibidir:<br/><br/>Randevu Tarihi: {appointment.DateTime},<br/>Klinik Adı: {appointment.Doctor.Clinic.Name}<br/>Hekim Adı: {appointment.Doctor.Title.TitleName} {appointment.Doctor.User.FirstName} {appointment.Doctor.User.LastName},<br/>Doktor Ofisi: {appointment.Doctor.OfficeLocation.Block.No + " Blok, " + appointment.Doctor.OfficeLocation.Floor.No + " Kat, Oda: " + appointment.Doctor.OfficeLocation.Room.No}<br/><br/>Görüş, öneri, şikayet ve tüm sorularınız için <strong><a href='mailto:iletisim-hrs@ahmetyuksel.com' style='text-decoration:none'>iletisim-hrs@ahmetyuksel.com</a></strong> adresine e-posta gönderebilirsiniz.<br/><br/><hr/><br/>Lütfen bu e-postayı yanıtlamayınız.<br/><br/>© Telif Hakkı 2024 HRS Hastane Randevu Sistemi - Tüm hakları saklıdır.";

            var msg = MailHelper.CreateSingleEmail(_fromAddress, to, subject, plainTextContent, htmlContent);
            var response = await _client.SendEmailAsync(msg);
        }

        public async Task SendFeedbackRequestEmailAsync(string userEmail, string userFeedback)
        {
            // iletisim - hrs  
            var subjectUser = "HRS Geri Bildirim Talebi";
            var toUser = new EmailAddress("iletisim-hrs@ahmetyuksel.com");
            var plainTextContentUser = $"Kullanıcı: {userEmail}\n\nGeri Bildirim: {userFeedback}";
            var htmlContentUser = $"Kullanıcı: <strong><a href='mailto:{userEmail}' style='text-decoration:none'>{userEmail}</a></strong><br/><br/>Geri Bildirim: {userFeedback}";
            var msgUser = MailHelper.CreateSingleEmail(_fromAddressFeedbackUser, toUser, subjectUser, plainTextContentUser, htmlContentUser);
            var responseUser = await _clientFeedbackUser.SendEmailAsync(msgUser);

            // noreply-hrs
            var subjectHRS = "HRS İçin Geri Bildirim";
            var toHRS = new EmailAddress(userEmail);

            var plainTextContentHRS = $"Sayın: {userEmail},\n\nGeri bildiriminiz başarıyla gönderildi.\n\nSistemimizi iyileştirmeye olan katkınız için teşekkür eder, iyi günler dileriz.\n\nSevgiler,\n\nHRS Hastane Randevu Sistemi\n\nLütfen bu e-postayı yanıtlamayınız.\n\n© Telif Hakkı 2024 HRS Hastane Randevu Sistemi - Tüm hakları saklıdır.";

            var htmlContentHRS = $"<strong>Sayın: {userEmail},</strong><br/><br/>Geri bildiriminiz başarıyla gönderildi.<br/><br/>Sistemimizi iyileştirmeye olan katkınız için teşekkür eder, iyi günler dileriz.<br/><br/>Sevgiler,<br/><br/>HRS Hastane Randevu Sistemi<br/><br/><hr/><br/>Lütfen bu e-postayı yanıtlamayınız.<br/><br/>© Telif Hakkı 2024 HRS Hastane Randevu Sistemi - Tüm hakları saklıdır.";

            var msgHRS = MailHelper.CreateSingleEmail(_fromAddress, toHRS, subjectHRS, plainTextContentHRS, htmlContentHRS);
            var responseHRS = await _client.SendEmailAsync(msgHRS);
        }

        public async Task SendWelcomeEmailAsync(string email, string userName)
        {
            var subject = "HRS Hastane Randevu Sistemi'ne Hoşgeldiniz";
            var to = new EmailAddress(email);

            var plainTextContent = $"Merhaba {userName},\n\nHRS Hastane Randevu Sistemi'ne hoşgeldiniz.\n\nKayıt işleminiz başarıyla gerçekleşmiş olup, sistemden randevunuzu alabilirsiniz.\n\nDetaylar için websitemizi ziyaret edebilir; görüş, öneri, şikayet ve tüm sorularınız için iletisim-hrs@ahmetyuksel.com adresine e-posta gönderebilirsiniz.\n\nLütfen bu e-postayı yanıtlamayınız.\n\n© Telif Hakkı 2024 HRS Hastane Randevu Sistemi - Tüm hakları saklıdır.";

            var htmlContent = $"<strong>Merhaba {userName},</strong><br/><br/>HRS Hastane Randevu Sistemi'ne hoşgeldiniz.<br/><br/>Kayıt işleminiz başarıyla gerçekleşmiş olup, sistemden randevunuzu alabilirsiniz.<br/><br/>Detaylar için websitemizi ziyaret edebilir;<br/> görüş, öneri, şikayet ve tüm sorularınız için <strong><a href='mailto:iletisim-hrs@ahmetyuksel.com' style='text-decoration:none'>iletisim-hrs@ahmetyuksel.com</a></strong> adresine e-posta gönderebilirsiniz.<br/><br/><hr/><br/>Lütfen bu e-postayı yanıtlamayınız.<br/><br/>© Telif Hakkı 2024 HRS Hastane Randevu Sistemi - Tüm hakları saklıdır.";

            var msg = MailHelper.CreateSingleEmail(_fromAddress, to, subject, plainTextContent, htmlContent);
            var response = await _client.SendEmailAsync(msg);
        }
    }
}
