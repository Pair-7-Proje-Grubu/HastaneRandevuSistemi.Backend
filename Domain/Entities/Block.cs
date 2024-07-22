using Core.Entities;

namespace Domain.Entities
{
    public class Block : BaseEntity
    {
        public string No { get; set; }
        public virtual ICollection<OfficeLocation> OfficeLocations { get; set; }

    }
}
