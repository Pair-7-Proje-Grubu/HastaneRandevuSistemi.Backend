using Core.Entities;

namespace Domain.Entities
{
    public class Admin : BaseEntity 
    {
        public virtual User User { get; set; }
    }
}
