using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services;
using Models;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RandomUserMeAsync().Wait();
        }

        public static async Task RandomUserMeAsync()
        {
            ForecastIO forecast = await RandomUserMeService.RandomUserMe();
            Console.WriteLine("####################################################################");
            Console.WriteLine("##                           RandomUserMe App                          ##");
            Console.WriteLine("## -------------------------------------------------------------- ##");
            Console.WriteLine("## Data from Forecast.io Service                                  ##");
            Console.WriteLine("## Developed by Jef Roosens                                       ##");
            Console.WriteLine("## Arteveldehogeschool                                            ##");
            Console.WriteLine("####################################################################");
            //Console.BackgroundColor = ConsoleColor.Blue;
            //Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Format("Weathersituation: {0}", forecast.Now.Summary));
            Console.WriteLine(String.Format("Gender: {0}", User.gender));
            //Console.ResetColor();
            Console.WriteLine("####################################################################");
        }
    }
}
