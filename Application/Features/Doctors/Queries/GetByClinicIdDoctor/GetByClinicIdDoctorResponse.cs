namespace Application.Features.Doctors.Queries.GetByClinicIdDoctor
{
    public class GetByClinicIdDoctorResponse
    {
        public int Id { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
    }
}
