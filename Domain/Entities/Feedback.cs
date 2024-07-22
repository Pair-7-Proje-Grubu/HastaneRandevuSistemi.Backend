using Core.Entities;

namespace Domain.Entities
{
    public class Feedback : BaseEntity
    {
        public string UserMail { get; set; }

        public string UserFeedback { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
