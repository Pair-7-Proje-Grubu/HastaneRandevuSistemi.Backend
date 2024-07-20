using Core.Entities;
using Domain.Enums;

namespace Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateTime { get; set; }
        public CancelStatus isCancelStatus { get; set; } = CancelStatus.NoCancel;
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
       

    }
 
}
