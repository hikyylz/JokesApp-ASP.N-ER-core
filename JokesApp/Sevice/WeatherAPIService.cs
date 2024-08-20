using JokesApp.Models;
using System.Xml.Linq;

namespace JokesApp.Sevice
{
    public class WeatherAPIService
    {
        private static string apikey = "a82233747252d5ab3cd24a75641df493";
        private static string selectedCity = "london";
        string connection = "https://api.openweathermap.org/data/2.5/weather?q="+selectedCity+"&mode=xml&appid="+apikey;

        public WeatherAPIService() { 
        
        }

        public WeatherForcastModel getWeatherModel()
        {
            XDocument document = XDocument.Load(connection);
            string tempValue = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            double doubleTempValue = Convert.ToDouble(tempValue)-273.15;
            doubleTempValue = Math.Round(doubleTempValue, 1);
            string countryValue = document.Descendants("city").ElementAt(0).Element("country").Value;
            string cityName = document.Descendants("city").ElementAt(0).Attribute("name").Value;

            return new WeatherForcastModel(doubleTempValue, countryValue, cityName);
        }
    }
}
