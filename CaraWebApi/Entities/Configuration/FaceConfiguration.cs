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
        public class FaceConfiguration : IEntityTypeConfiguration<Face>
    {
        public void Configure(EntityTypeBuilder<Face> builder)
        {
            builder.HasData
            (
                new Face
                {
                    Id = 1,
                    Name = "Mohd Rosdi",
                    UserId = "CCM025",
                    FaceTemperature = 36.69228744506836,
                    TemperatureAlarm = "Normal",
                    Timestamp = 1635312105,
                    ScanId = 1
                },
                new Face
                {
                    Id = 2,
                    Name = "Siti Seha",
                    UserId = "CCM026",
                    FaceTemperature = 36.69228744506836,
                    TemperatureAlarm = "Normal",
                    Timestamp = 1635312205,
                    ScanId = 2
                }
            );
        }
    }
}
