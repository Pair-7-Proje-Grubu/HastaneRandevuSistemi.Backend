using Core.Entities;
using Domain.Enums;

namespace Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
       

    }
 
}
