using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace DecoratedWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                Console.WriteLine("Call to Live API");
                Console.WriteLine("==============================");
                var response1 = client.GetAsync(baseAddress + "api/accounts/123456").Result;

                Console.WriteLine(response1);
                Console.WriteLine(response1.Content.ReadAsStringAsync().Result);
                Console.WriteLine();

                Console.WriteLine("Call to Mock API - Mock Behaviour");
                Console.WriteLine("==============================");
                var response3 = client.GetAsync(baseAddress + "api/QA/accounts/123456").Result;

                Console.WriteLine(response3);
                Console.WriteLine(response3.Content.ReadAsStringAsync().Result);
                Console.WriteLine();
                
                Console.WriteLine("Call to Mock API - Live behaviour");
                Console.WriteLine("==============================");
                var response2 = client.GetAsync(baseAddress + "api/QA/accounts/223344").Result;

                Console.WriteLine(response2);
                Console.WriteLine(response2.Content.ReadAsStringAsync().Result);
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
