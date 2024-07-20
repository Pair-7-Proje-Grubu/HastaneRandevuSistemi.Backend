using Domain.Enums;

namespace Application.Features.Appointments.Queries.GetListAppointment
{
    public class GetListAppointmentResponse
    {
        public DateTime DateTime { get; set; }
        public string OfficeLocation { get; set; }
        public string Doctor { get; set; }
        public string Clinic { get; set; }
        public CancelStatus CancelStatus { get; set; }

    }
}