namespace Application.Features.Users.Commands.Update
{
    public class ChangePhoneNumberResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}