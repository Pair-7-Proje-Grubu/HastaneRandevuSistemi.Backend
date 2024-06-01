using Core.Entities;

namespace Domain.Entities
{
    public class Title : BaseEntity
    {
        public string TitleName { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}