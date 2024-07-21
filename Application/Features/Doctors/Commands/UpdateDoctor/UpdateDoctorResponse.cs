using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorResponse
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int TitleId { get; set; }
    }
}
