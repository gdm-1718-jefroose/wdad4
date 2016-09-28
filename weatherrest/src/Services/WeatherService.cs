using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using Models;

namespace Services
{
    public class WeatherService
    {
        private static string KEY = "9becf03e0e56f7a000698471995ba990";
        private static string API = "https://api.darksky.net/forecast/{0}/{1},{2}?unites={3}"; 
        
        public WeatherService()
        {

        }

        public static async Task<ForecastIO> GetWeatherFromLatLng(string lat, string lng, string unit = "si")
        {
            var url = String.Format(WeatherService.API, WeatherService.KEY, lat, lng, unit);

            using(var handler = new HttpClientHandler())
            {
                handler.AllowAutoRedirect = false;

                using(var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear()
                    HttpResponseMessage response = await client.GetAsync(url);
                    if(response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var serializer = new DataContractJsonSerializer(typeof(ForecastIO));
                        var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
                        ForecastIO forecastIO = (ForecastIO)serializer.ReadObject(ms);

                        return forecastIO;

                    }
                }
            }
            return null;
        }
    }
}