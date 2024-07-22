namespace Application.Features.WorkingTimes.Commands.Update
{
    public class UpdateWorkingTimeResponse
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan StartBreakTime { get; set; }
        public TimeSpan EndBreakTime { get; set; }
    }
}
