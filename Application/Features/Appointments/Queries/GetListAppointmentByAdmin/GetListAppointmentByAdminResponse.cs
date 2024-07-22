using Domain.Enums;

namespace Application.Features.Appointments.Queries.GetListAppointmentByAdmin
{
    public class GetListAppointmentByAdminResponse
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string ClinicName { get; set; }
        public DateTime DateTime { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
