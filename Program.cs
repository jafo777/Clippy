using Microsoft.Owin.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClippyAPI
{
    public class Program
    {
        [STAThreadAttribute]
        static void Main()
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpClient and make a request to api/values 
                HttpClient client = new HttpClient();


                var content = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string, string>("", "login")
                });

                var POST = client.PostAsync(baseAddress + "api/clippy/", content);
                var response = client.GetAsync(baseAddress + "api/clippy/").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine();
            }
        }
    }
}
