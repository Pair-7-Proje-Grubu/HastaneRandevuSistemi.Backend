using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Queries.GetListDoctorOfficeLocation
{
    public class DoctorOfficeLocationListResponse
    {
        public string FullName { get; set; }
        public int DoctorId { get; set; }
        public string BlockNo { get; set; }
        public string FloorNo { get; set; }
        public string RoomNo { get; set; }
        public int BlockId { get; set; }
        public int FloorId { get; set; }
        public int RoomId { get; set; }
    }
}
