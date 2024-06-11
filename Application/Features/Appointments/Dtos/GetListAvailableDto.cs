using Application.Features.Appointments.Queries.GetListAvailableAppointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Dtos
{
    public class GetListAvailableDto
    {
        public string DoctorName { get; set; }
        public string ClinicName { get; set; }
        public string OfficeLocation { get; set; }
        public List<AppointmentDate> AppointmentDates { get; set; } //10 günlük
    }
    public class AppointmentDate
    {
        public DateTime Date { get; set; }
        public List<DateRange> Range { get; set; }
    }

    public class DateRange
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

}
