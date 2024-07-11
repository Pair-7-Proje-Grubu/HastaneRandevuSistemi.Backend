namespace Application.Features.Users.Commands.Update.ChangePhoneNumber
{
    public class ChangePhoneNumberResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}