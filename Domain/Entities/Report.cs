using Core.Entities;

namespace Domain.Entities
{
    public class Report : BaseEntity
    {
        public int AppointmentId { get; set; }
        public string Description { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
