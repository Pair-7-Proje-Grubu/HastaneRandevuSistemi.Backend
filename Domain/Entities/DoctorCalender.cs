using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DoctorCalender
    {
        //TODO
        public int DateId { get; set;}
        public int StartHour { get; set;}
        public int EndHour { get; set;}
        public bool IsBusy { get; set;}

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
