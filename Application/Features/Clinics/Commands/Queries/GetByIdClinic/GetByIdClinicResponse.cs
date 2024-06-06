using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clinics.Commands.Queries.GetByIdClinic
{
    public class GetByIdClinicResponse
    {
        public Clinic? Clinic { get; set; }
    }
}
