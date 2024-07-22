using Domain.Entities;

namespace Application.Services.EmailService
{
    public interface IEmailService
    {
        Task SendAppointmentInformationEmailAsync(string email, Appointment appointment);
        Task SendWelcomeEmailAsync(string email, string userName);
        Task SendFeedbackRequestEmailAsync(string userEmail, string userFeedback);
        Task SendCancelAppointmentByDoctorInformationEmailAsync(string email, Appointment appointment);
        Task SendCancelAppointmentByPatientInformationEmailAsync(string email, Appointment appointment);
    }
}