namespace Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorResponse
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int ClinicId { get; set; }
        public int OfficeLocationId { get; set; }
    }
}
