﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherHistory.Shared.DTOs
{
    public class TemperatureDTO
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public DateTime Date { get; set; }
        public string WeatherName { get; set; }
        public string CityName { get; set; }
    }
}
