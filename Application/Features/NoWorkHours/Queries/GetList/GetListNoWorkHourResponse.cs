namespace Application.Features.NoWorkHours.Queries.GetList
{
    public class GetListNoWorkHourResponse
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
    }
}
