using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public partial class ScanData
    {
        [Key]
        [Column("ScanId")]
        public int Id { get; set; }

        [JsonProperty("camid")]
        public string Camid { get; set; }

        [JsonProperty("devid")]
        public string Devid { get; set; }

        [JsonProperty("devmac")]
        public string Devmac { get; set; }

        [JsonProperty("devname")]
        public string Devname { get; set; }

        [JsonProperty("devno")]
        public string Devno { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
        [JsonProperty("faces")]
        public List<Face> Faces { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("timelocal")]
        public int Timelocal { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public DateTime LoggedDate { get; set; } = DateTime.Now;

        public string GetScanLocation()
        {
            return $"{this.Devid}, {this.Devname}";
        }
    }
}
