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
    public class ScanForCreationDto
    {
        [JsonProperty("camid")]
        public string Camid { get; set; }

        [JsonProperty("devid")]
        public string Devid { get; set; }
        [JsonProperty("devname")]
        public string Devname { get; set; }
        [JsonProperty("devno")]
        public string Devno { get; set; }
        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("timelocal")]
        public string Timelocal { get; set; }

        public DateTime PublishedDate { get; set; }

        public List<Face> Faces { get; set; }

    }
}
