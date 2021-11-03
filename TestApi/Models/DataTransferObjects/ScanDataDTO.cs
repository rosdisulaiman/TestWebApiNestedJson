﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Models.DataTransferObjects
{
    public class ScanDataDTO
    {
        public int ScanId { get; set; }
        public DateTime LoggedTime { get; set; }
        public string ScanLocation { get; set; }
        public List<FaceDto> Faces { get; set; }
    }
}
