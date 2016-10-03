using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using Models;

namespace Services
{
    public class GentseFeestenService
    {
        private static string GENTSEFEESTENCATEGORIES = "https://datatank.stad.gent/4/toerisme/gentsefeestencategorien.json";
        private static string GENTSEFEESTENLOCATIES = "https://datatank.stad.gent/4/cultuursportvrijetijd/gentsefeestenlocaties.json";
        private static string GENTSEFEESTENDATA = "https://datatank.stad.gent/4/cultuursportvrijetijd/gentsefeestendata.json";
        private static string GENTSEFEESTENEVENTS = "https://datatank.stad.gent/4/toerisme/gentsefeestenevents.json?limit=5";
        
        public GentseFeestenService() 
        {
        }

        public static async Task<List<GentseFeestenCategory>> GetGentseFeestenCategories()
        {
            string url = GentseFeestenService.GENTSEFEESTENCATEGORIES;

            using (var handler = new HttpClientHandler())
            {
                handler.AllowAutoRedirect = true;
                
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var result = DeserializeJSON<List<GentseFeestenCategory>>(jsonString);
                        
                        return result;
                    };
                }
            }
            return null;
        }

        public static async Task<List<GentseFeestenLocation>> GetGentseFeestenLocations()
        {
            string url = GentseFeestenService.GENTSEFEESTENLOCATIES;

            using (var handler = new HttpClientHandler())
            {
                handler.AllowAutoRedirect = true;
                
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var result = DeserializeJSON<List<GentseFeestenLocation>>(jsonString);
                        
                        return result;
                    };
                }
            }
            return null;
        }

        public static async Task<List<GentseFeestenData>> GetGentseFeestenData()
        {
            string url = GentseFeestenService.GENTSEFEESTENDATA;

            using (var handler = new HttpClientHandler())
            {
                handler.AllowAutoRedirect = true;
                
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var result = DeserializeJSON<List<GentseFeestenData>>(jsonString);
                        
                        return result;
                    };
                }
            }
            return null;
        }

        public static async Task<List<GentseFeestenEvent>> GetGentseFeestenEvents()
        {
            string url = GentseFeestenService.GENTSEFEESTENEVENTS;

            using (var handler = new HttpClientHandler())
            {
                handler.AllowAutoRedirect = true;
                
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var result = DeserializeJSON<List<GentseFeestenEvent>>(jsonString);
                        
                        return result;
                    };
                }
            }
            return null;
        }

        public static T DeserializeJSON<T>(string jsonString) 
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(stream);
            return obj;
        }
    }
}
