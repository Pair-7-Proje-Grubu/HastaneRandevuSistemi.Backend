namespace Application.Features.Appointments.Queries.GetListActiveAppointment
{
    public class GetListActiveAppointmentByDoctorResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
