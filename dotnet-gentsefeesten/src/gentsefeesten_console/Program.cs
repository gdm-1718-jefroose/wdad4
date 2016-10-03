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
            Console.WriteLine("##################################################################################");
            Console.WriteLine("#                              GENTSE FEESTEN                                    #");
            Console.WriteLine("##################################################################################");
            //RunGentseFeestenCategoriesAsync().Wait();
            //RunGentseFeestenLocationsAsync().Wait();
            //RunGentseFeestenDataAsync().Wait();
            RunGentseFeestenEventsAsync().Wait();
            Console.WriteLine("##################################################################################");
        }


        public static async Task RunGentseFeestenCategoriesAsync()
        {
            List<GentseFeestenCategory> gentsefeestenCategories = await GentseFeestenService.GetGentseFeestenCategories();
            foreach(var gentsefeestenCategory in gentsefeestenCategories)
            {
                Console.WriteLine("# {0,-60}{1,20}",gentsefeestenCategory.ToString(),'#');
            }
        }

        public static async Task RunGentseFeestenLocationsAsync()
        {
            List<GentseFeestenLocation> gentsefeestenLocations = await GentseFeestenService.GetGentseFeestenLocations();
            foreach(var gentsefeestenLocation in gentsefeestenLocations)
            {
                Console.WriteLine("# {0,-60}{1,20}",gentsefeestenLocation.ToString(),'#');
            }
        }

        public static async Task RunGentseFeestenDataAsync()
        {
            List<GentseFeestenData> gentsefeestenLocations = await GentseFeestenService.GetGentseFeestenData();
            foreach(var gentsefeestenLocation in gentsefeestenLocations)
            {
                Console.WriteLine("# {0,-60}{1,20}",gentsefeestenLocation.ToString(),'#');
            }
        }

        public static async Task RunGentseFeestenEventsAsync()
        {
            List<GentseFeestenEvent> gentsefeestenEvents = await GentseFeestenService.GetGentseFeestenEvents();
            foreach(var gentsefeestenEvent in gentsefeestenEvents)
            {
                Console.WriteLine(gentsefeestenEvent.ToString());
                Console.WriteLine("----------------------------------------------------------------------------------");
            }
        }
        
    }
}
