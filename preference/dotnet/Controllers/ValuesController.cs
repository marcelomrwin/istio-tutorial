using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace dotnet.Controllers
{
    [Route("/")]
    public class ValuesController : Controller
    {
        const string url = "http://recommendation:8080";
        const string responseStringFormat = "preference from {0} => {1}\n";

        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public string Get()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Customer App");

            var msg = client.GetStringAsync(url).Result;

            string hostname = Dns.GetHostName();            
            return String.Format(responseStringFormat, hostname, msg);
        }
    }
}
