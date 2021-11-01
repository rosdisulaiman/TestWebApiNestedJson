﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class FaceForCreationDto
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public double FaceTemperature { get; set; }
        public string TemperatureAlarm { get; set; }
        public long Timestamp { get; set; }
        public string UserId { get; set; }
    }
}
