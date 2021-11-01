using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestApi.Models
{
    public class Face
    {
        [Key]
        public int FaceId { get; set; }
        [JsonProperty("QRcode")]
        public string QRcode { get; set; }

        //[JsonProperty("Temperature")]
        //public string Temperature { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("attrAge")]
        public int AttrAge { get; set; }

        [JsonProperty("attrBeauty")]
        public int AttrBeauty { get; set; }

        [JsonProperty("authType")]
        public string AuthType { get; set; }

        [JsonProperty("cardNum")]
        public string CardNum { get; set; }

        [JsonProperty("certificateNumber")]
        public string CertificateNumber { get; set; }

        [JsonProperty("certificateType")]
        public int CertificateType { get; set; }

        [JsonProperty("commonUuid")]
        public string CommonUuid { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("ethic")]
        public string Ethic { get; set; }

        [JsonProperty("feature")]
        [NotMapped]
        public List<double> Feature { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("groupId")]
        public string GroupId { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("irimg")]
        public string Irimg { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("orgimg")]
        public string Orgimg { get; set; }

        [JsonProperty("personId")]
        public string PersonId { get; set; }

        [JsonProperty("personUuid")]
        public string PersonUuid { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("plateId")]
        public string PlateId { get; set; }

        [JsonProperty("similarity")]
        public double Similarity { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("temperature")]
        public double FaceTemperature { get; set; }

        [JsonProperty("temperatureAlarm")]
        public string TemperatureAlarm { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("trackId")]
        public int TrackId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
        public int ScanId { get; set; }
        public ScanData ScanDatas { get; set; }
    }
}
