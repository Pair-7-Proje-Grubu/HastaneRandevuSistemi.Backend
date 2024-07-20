using Domain.Enums;

namespace Application.Features.Appointments.Commands.Book
{
    public class BookAppointmentResponse
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        public CancelStatus isCancelStatus { get; set; }
    }
}
