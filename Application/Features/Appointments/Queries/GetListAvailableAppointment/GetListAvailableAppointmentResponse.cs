using Application.Features.Appointments.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Features.Appointments.Queries.GetListAvailableAppointment
{
    public class GetListAvailableAppointmentResponse
    {
        public List<GetListAvailableDto> GetListAvailableDtos { get; set; }
        
    }  
}
