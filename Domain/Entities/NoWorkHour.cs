using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class NoWorkHour : BaseEntity
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsFullDay { get; set; }

        public Doctor Doctor { get; set; }

        //public DateTime DateTime;

        //public virtual Doctor Doctor { get; set; }
    }
}
