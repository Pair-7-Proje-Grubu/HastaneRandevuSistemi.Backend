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
        public int AppointmentDuration { get; set; }
        public List<AppointmentDate> AppointmentDates { get; set; } //10 günlük
    }

    public class AppointmentDate
    {
        public DateTime Date { get; set; }
        public List<TimeSpan> BookedSlots {  get; set; }
        public List<DateRange> Ranges { get; set; }
    }

    public class DateRange
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
