namespace Application.Features.WorkingTimes.Queries.GetById
{
    public class GetByIdWorkingTimeResponse
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan StartBreakTime { get; set; }
        public TimeSpan EndBreakTime { get; set; }
    }
}
