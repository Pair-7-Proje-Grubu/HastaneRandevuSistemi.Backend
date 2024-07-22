namespace Application.Features.Reports.Commands.Create
{
    public class CreateReportResponse
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public string Description { get; set; }
    }
}
