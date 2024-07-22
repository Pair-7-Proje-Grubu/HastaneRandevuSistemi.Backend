using Core.Entities;

namespace Domain.Entities
{
    public class NoWorkHour : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public virtual ICollection<DoctorNoWorkHour> DoctorNoWorkHours { get; set; }
    }
}