namespace Core.Entities
{
    public class BaseUser : BaseEntity
    {
  
        public string Email { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }


  


    }
}