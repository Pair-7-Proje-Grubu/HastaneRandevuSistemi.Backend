namespace Application.Features.OfficeLocations.Queries.GetList
{
    public class GetListOfficeLocationResponse
    {
        public int Id { get; set; }
        public string BlockNo { get; set; }
        public string FloorNo { get; set; }
        public string RoomNo { get; set; }
        public int BlockId { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }
    }
}
