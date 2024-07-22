namespace Application.Features.Doctors.Queries.GetByIdDoctor
{
    public class GetByIdDoctorResponse
    {
        public int TitleId { get; set; }
        public int ClinicId { get; set; }
        public int OfficeLocationId { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
    }
}
