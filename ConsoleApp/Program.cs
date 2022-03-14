using System;
using System.Net.Http;
using DataModel;
using DataServices;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            IHttpClientService client = new HttpClientService(new HttpClient() { BaseAddress = new Uri("Https://localhost:44338") });

            if(client.login("powell.paul@itsligo.ie", "Rad302$1").Result)
            {
                Console.WriteLine("Logged In");
                Console.WriteLine("Token is: {0}", client.UserToken);
            }
            var widgets = client.getCollection<Widget>("GetAll").Result;
                Console.WriteLine("Wdiget Count {0}",widgets.Count);
        }
    }
}
