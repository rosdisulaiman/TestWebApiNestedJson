using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class ScanConfiguration : IEntityTypeConfiguration<ScanData>
    {
        public void Configure(EntityTypeBuilder<ScanData> builder)
        {
            builder.HasData
            (
                new ScanData
                {
                    Id = 1,
                    Camid = "Camera0",
                    Devid = "FF008100",
                    Devmac = "",
                    Devname = "Device IN",
                    Devno = "",
                    Event = "common",
                    Operator = "faceRegCaptureUpload",
                    Time = 1635312120,
                    Timelocal = 1635312105
                },
                new ScanData
                {
                    Id = 2,
                    Camid = "Camera1",
                    Devid = "101",
                    Devmac = "",
                    Devname = "Device OUT",
                    Devno = "",
                    Event = "common",
                    Operator = "faceRegCaptureUpload",
                    Time = 1635312120,
                    Timelocal = 1635312105
                }
            );
        }
    }

}
