using Domain.Enums;

namespace Domain.Entities
{
    public class Patient : User
    {
        public BloodType? BloodType { get; set; }
        public string? EmergencyContact { get; set; }
        public virtual ICollection<Allergy> Allergies { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
