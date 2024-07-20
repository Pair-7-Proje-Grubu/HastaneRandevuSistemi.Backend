using Domain.Enums;

namespace Application.Features.Appointments.Commands.Update
{
    public class UpdateAppointmentCommand
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
