using System;
using System.Threading.Tasks;
using Services;
using Models;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunWeatherService().Wait();
        }

        public static async Task RunWeatherService()
        {
            ForecastIO forecastIO = await WeatherService.GetWeatherFromLatLng("51.039889", "3.725620");

            Console.WriteLine(forecastIO);
        }
    }
}
