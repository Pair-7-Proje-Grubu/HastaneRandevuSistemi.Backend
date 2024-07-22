using Core.Entities;

namespace Domain.Entities
{
    public class Clinic : BaseEntity
    {
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public int AppointmentDuration { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
