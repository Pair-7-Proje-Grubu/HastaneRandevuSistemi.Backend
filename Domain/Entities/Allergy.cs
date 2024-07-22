using Core.Entities;

namespace Domain.Entities
{
    public class Allergy : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
