namespace Application.Features.Appointments.Queries.GetListAppointment
{
    public class GetListAppointmentResponse
    {
        public DateTime DateTime { get; set; }
        public string OfficeLocation { get; set; }
        public string DoctorName { get; set; }
        public string ClinicName { get; set; }
    }
}