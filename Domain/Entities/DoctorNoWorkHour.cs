using Core.Entities;

namespace Domain.Entities
{
    public class DoctorNoWorkHour : BaseEntity
    {
        public int DoctorId { get; set; }
        public int NoWorkHourId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual NoWorkHour NoWorkHour { get; set; }
    }
}
