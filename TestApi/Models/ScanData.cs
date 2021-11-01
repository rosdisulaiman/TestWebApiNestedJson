using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestApi.Models
{
    public partial class ScanData
        
    {
        [Key]
        public int ScanId { get; set; }

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
        
        public List<Face> Faces { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("timelocal")]
        public int Timelocal { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Now;
    }

    public partial class ScanData
    {
        public static ScanData FromJson(string json) => JsonConvert.DeserializeObject<ScanData>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ScanData self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}





