using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Face
    {
        [Key]
        [Column("FaceId")]
        public int Id { get; set; }

        [Column("QRcode")]
        public string QRcode { get; set; }

        //[JsonProperty("Temperature")]
        //public string ATemperature { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("attrAge")]
        public int AttrAge { get; set; }

        [Column("attrBeauty")]
        public int AttrBeauty { get; set; }

        [Column("authType")]
        public string AuthType { get; set; }

        [Column("cardNum")]
        public string CardNum { get; set; }

        [Column("certificateNumber")]
        public string CertificateNumber { get; set; }

        [Column("certificateType")]
        public int CertificateType { get; set; }

        [Column("commonUuid")]
        public string CommonUuid { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("ethic")]
        public string Ethic { get; set; }

        [Column("feature")]
        [NotMapped]
        public List<double> Feature { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("groupId")]
        public string GroupId { get; set; }

        [Column("image")]
        public string Image { get; set; }

        [Column("irimg")]
        public string Irimg { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("orgimg")]
        public string Orgimg { get; set; }

        [Column("personId")]
        public string PersonId { get; set; }

        [Column("personUuid")]
        public string PersonUuid { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("plateId")]
        public string PlateId { get; set; }

        [Column("similarity")]
        public double Similarity { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [JsonProperty("temperature")]
        public double FaceTemperature { get; set; }

        [Column("temperatureAlarm")]
        public string TemperatureAlarm { get; set; }

        [Column("timestamp")]
        public long Timestamp { get; set; }

        [Column("trackId")]
        public int TrackId { get; set; }

        [Column("userId")]
        public string UserId { get; set; }

        [ForeignKey(nameof(ScanData))]
        public int ScanId { get; set; }
        public ScanData ScanData { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
    
}
