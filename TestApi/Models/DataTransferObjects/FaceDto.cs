using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Models.DataTransferObjects
{
    public class FaceDto
    {
        public int FaceId { get; set; }
        public string name { get; set; }
        public string userId { get; set; }
        public string email { get; set; }
        public string QRcode { get; set; }
        public string address { get; set; }
        public int age { get; set; }
        public string authType { get; set; }
        public string cardNum { get; set; }
        public string certificateNumber { get; set; }
        public int certificateType { get; set; }
        public string commonUuid { get; set; }
        public string ethic { get; set; }
        public string gender { get; set; }
        public string groupId { get; set; }
        public string personId { get; set; }
        public string personUuid { get; set; }
        public string phone { get; set; }
        public string plateId { get; set; }
        public float temperature { get; set; }
        public string temperatureAlarm { get; set; }
        public int timestamp { get; set; }
        public int trackId { get; set; }
        public string image { get; set; }
        public string irimg { get; set; }
        public string orgimg { get; set; }
    }
}
