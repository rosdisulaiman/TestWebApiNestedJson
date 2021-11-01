using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public string FullAddress { get; set; }
    }
}
