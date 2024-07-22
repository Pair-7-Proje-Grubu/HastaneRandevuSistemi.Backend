namespace Application.Features.Reports.Commands.Update
{
    public class UpdateReportResponse
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public string Description { get; set; }
    }
}
