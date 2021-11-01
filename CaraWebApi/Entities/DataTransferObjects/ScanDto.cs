using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ScanDto
    {
        public int Id { get; set; }
        public string ScanLocation { get; set; }
        public int Time { get; set; }
        public DateTime LoggedDate { get; set; }
    }
}
