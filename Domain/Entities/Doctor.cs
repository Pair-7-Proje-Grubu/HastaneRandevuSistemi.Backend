using Core.Entities;

namespace Domain.Entities
{
    public class Doctor : User
    {   
        public int TitleId { get; set; }
        public int ClinicId { get; set; }
        public int OfficeLocationId { get; set; }

        public virtual Title Title { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual OfficeLocation OfficeLocation { get; set; }
        public virtual ICollection<NoWorkHour> NoWorkHours { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }


    }
}