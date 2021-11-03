using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Customization
{
    public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            var dates = source.Split(".");

            return new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]));
        }

    }
}
