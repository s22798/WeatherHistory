namespace WeatherHistory.Server.Models
{
    public class Location
    {
        public int IdLocation { get; set; }
        public string Name { get; set; }
        public ICollection<Temperature> Temperatures { get; set; }
    }
}
