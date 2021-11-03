using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string camid { get; set; }
        public string devid { get; set; }
        public string devmac { get; set; }
        public string devname { get; set; }
        public string devno { get; set; }
        [Column("event")]
        public string _event { get; set; }
        public List<Face> Faces { get; set; }
        [Column("operator")]
        public string Operator { get; set; }
        public int time { get; set; }
        public int timelocal { get; set; }
        public string type { get; set; }
        public DateTime LoggedTime { get; set; } = DateTime.Now;
    }
}
