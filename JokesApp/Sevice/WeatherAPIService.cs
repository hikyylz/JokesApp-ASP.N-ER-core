using JokesApp.Models;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;


namespace JokesApp.Sevice
{
    public class WeatherAPIService
    {
        private static string apikey = "a82233747252d5ab3cd24a75641df493";
        private static string[] selectedCities = ["london", "berlin", "istanbul"];
        private ArrayList connections = new ArrayList();


        public WeatherAPIService() {
            prepareHTMLConnections();
        }

        public void prepareHTMLConnections()
        {
            foreach (var city in selectedCities)
            {
                string connection = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&appid=" + apikey;
                connections.Add(connection);
            }

        }

        public List<WeatherForcastModel> getWeatherModels()
        {
            List < WeatherForcastModel > modelsList = new List < WeatherForcastModel >();

            foreach (var connection in connections)
            {
                XDocument document = XDocument.Load((string)connection);
                string tempValue = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                double doubleTempValue = Convert.ToDouble(tempValue) - 273.15;
                doubleTempValue = Math.Round(doubleTempValue, 1);
                string countryValue = document.Descendants("city").ElementAt(0).Element("country").Value;
                string cityName = document.Descendants("city").ElementAt(0).Attribute("name").Value;
                
                modelsList.Add(new WeatherForcastModel(doubleTempValue, countryValue, cityName));
            }
            
            return modelsList;
        }
    }
}
