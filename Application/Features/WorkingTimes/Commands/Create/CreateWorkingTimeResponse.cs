namespace Application.Features.WorkingTimes.Commands.Create
{
    public class CreateWorkingTimeResponse
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan StartBreakTime { get; set; }
        public TimeSpan EndBreakTime { get; set; }
    }
}