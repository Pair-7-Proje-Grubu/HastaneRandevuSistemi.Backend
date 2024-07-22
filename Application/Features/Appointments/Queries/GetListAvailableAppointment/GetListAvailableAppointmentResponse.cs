namespace Application.Features.Appointments.Queries.GetListAvailableAppointment
{
    public class GetListAvailableAppointmentResponse
    {
        public int AppointmentDuration { get; set; }
        public List<AppointmentDate> AppointmentDates { get; set; }
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
