namespace WeatherHistory.Server.Models
{
    public class Temperature
    {
        public int IdTemperature { get; set; }
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public string WeatherName { get; set; }
        public DateTime Date { get; set; }
        public int IdLocation { get; set; }
        public virtual Location Location { get; set; }
    }
}
