using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Commands.UpdateDoctorOfficeLocation
{
    public class UpdateDoctorOfficeLocationResponse
    {
        public string FullName { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public string Block { get; set; }
    }
}
