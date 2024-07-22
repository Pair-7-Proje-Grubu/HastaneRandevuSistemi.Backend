namespace Application.Features.Users.Queries.GetProfile
{
    public class GetProfileResponse
    {
        public string FirstName {  get; set; }
        public string LastName {  get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
    }
}
