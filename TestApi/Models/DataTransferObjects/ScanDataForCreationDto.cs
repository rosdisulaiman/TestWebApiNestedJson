using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Models.DataTransferObjects
{
    public class ScanDataForCreationDto
    {
        public int ScanId { get; set; }
        public DateTime LoggedTime { get; set; } = DateTime.Now;
        public string ScanLocation { get; set; }
        public List<FaceDto> Faces { get; set; }
    }
}
