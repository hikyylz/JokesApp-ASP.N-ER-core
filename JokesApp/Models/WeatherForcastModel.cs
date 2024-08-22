using System.ComponentModel.DataAnnotations;

namespace JokesApp.Models
{
    public class WeatherForcastModel
    {
        [Key]
        public int id { get; set; }
        public double tempValue {  get; set; }
        public string country {  get; set; }
        public string cityName { get; set; }

        public WeatherForcastModel(double tempValue, string country, string cityName) 
        {
            this.tempValue = tempValue;
            this.country = country;
            this.cityName = cityName;
        }

    }
}
