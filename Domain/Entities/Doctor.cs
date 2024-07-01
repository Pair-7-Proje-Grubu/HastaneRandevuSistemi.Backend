using Core.Entities;

namespace Domain.Entities
{
    public class Doctor : BaseEntity
    {
        
        public int TitleId { get; set; }
        public int ClinicId { get; set; }
        public int OfficeLocationId { get; set; }

        public virtual User User { get; set; }
        public virtual Title Title { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual OfficeLocation OfficeLocation { get; set; }
        public virtual ICollection<DoctorNoWorkHour> DoctorNoWorkHours { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}