using Domain.Enums;

namespace Application.Features.Appointments.Commands.Cancel.ByDoctor
{
    public class CancelAppointmentByDoctorResponse
    {
        public int Id { get; set; }
        public string Patient { get; set; }
        public DateTime DateTime { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
