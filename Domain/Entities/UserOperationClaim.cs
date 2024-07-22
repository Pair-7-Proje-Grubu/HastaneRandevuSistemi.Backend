using Core.Entities;

namespace Domain.Entities
{
    public class UserOperationClaim : BaseUserOperationClaim
    {
        public virtual User User {  get; set; }
        public virtual OperationClaim OperationClaim { get; set; }

    }
}
