using Core.Entities;

namespace Domain.Entities
{
    public class User : BaseUser
    {
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }

        
        public virtual List<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
