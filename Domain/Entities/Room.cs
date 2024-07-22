using Core.Entities;

namespace Domain.Entities
{
    public class Room : BaseEntity
    {
        public string No { get; set; }
        public virtual ICollection<OfficeLocation> OfficeLocations { get; set; }
    }
}
