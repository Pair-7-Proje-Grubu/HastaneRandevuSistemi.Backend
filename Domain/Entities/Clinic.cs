using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Clinic : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
