using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherHistory.Shared.DTOs
{
    public class LocationDTO
    {
        public string Name { get; set; }
        [JsonIgnore]
        public double LastTemperature { get; set; }
    }
}
