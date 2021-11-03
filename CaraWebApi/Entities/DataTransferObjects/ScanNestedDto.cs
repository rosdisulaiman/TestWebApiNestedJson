using Entities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ScanNestedDto
    {

        public int Id { get; set; }
        public string ScanLocation { get; set; }
        public int Time { get; set; }
        public DateTime LoggedDate { get; set; }
        public string Image { get; set; }
        public string name { get; set; }
        public double FaceTemperature { get; set; }
        public string TemperatureAlarm { get; set; }
        public long Timestamp { get; set; }
        public string UserId { get; set; }

    }
}
