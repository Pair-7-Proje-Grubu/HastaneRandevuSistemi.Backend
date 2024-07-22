using Core.Entities;
namespace Domain.Entities
{
    public class OperationClaim : BaseOperationClaim
    {
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
