namespace Application.Features.OfficeLocations.Commands.Create
{
    public class CreateOfficeLocationResponse
    {
        public int Id { get; set; }
        public int BlockId { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }
    }
}
