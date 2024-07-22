namespace Application.Features.Clinics.Commands.Create
{
    public class CreateClinicResponse
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int AppointmentDuration { get; set; }    
    }
}
