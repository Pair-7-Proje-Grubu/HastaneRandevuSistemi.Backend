using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clinics.Queries.GetByIdClinic
{
    public class GetByIdClinicResponse
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int AppointmentDuration { get; set; }
    }
}
