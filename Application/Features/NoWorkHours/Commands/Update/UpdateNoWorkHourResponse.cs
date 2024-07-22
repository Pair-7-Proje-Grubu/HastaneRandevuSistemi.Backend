namespace Application.Features.NoWorkHours.Commands.Update
{
    public class UpdateNoWorkHourResponse
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
    }
}
