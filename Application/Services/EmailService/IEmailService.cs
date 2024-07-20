using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.EmailService
{
    public interface IEmailService
    {
        Task SendAppointmentInformationEmailAsync(string email, Appointment appointment);
        Task SendWelcomeEmailAsync(string email, string userName);
        Task SendFeedbackRequestEmailAsync(string userEmail, string userFeedback);
    }
}