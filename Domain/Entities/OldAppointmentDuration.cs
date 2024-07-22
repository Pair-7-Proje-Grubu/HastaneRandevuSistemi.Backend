using Core.Entities;

namespace Domain.Entities
{
    public class OldAppointmentDuration  : BaseEntity
    {
        public int ClinicId {  get; set; }  
        public int Duration { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
