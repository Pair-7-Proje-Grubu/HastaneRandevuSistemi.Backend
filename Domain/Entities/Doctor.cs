
namespace Core.Entities
{
    public class Doctor : BaseUser
    {   
        public int TitleId { get; set; }
        public int ClinicId { get; set; }
        public int OfficeId { get; set; }
        public virtual Title Title { get; set; }

    }
}