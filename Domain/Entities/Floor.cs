using Core.Entities;

namespace Domain.Entities
{
    public class Floor : BaseEntity
    {
        public string No { get; set; }
        public virtual ICollection<OfficeLocation> OfficeLocations { get; set; }

    }
}
