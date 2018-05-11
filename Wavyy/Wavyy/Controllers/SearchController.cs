using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Wavyy.Models;

namespace Wavyy.Controllers
{
    public class SearchController : Controller
    {
        static HttpClient client = new HttpClient();

        private const string URL = "https://api-endpoint.igdb.com/";
        private string userKey = "befc5535687e5de93cfd50d93bf10669";

        private static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("user-key", "befc5535687e5de93cfd50d93bf10669");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SearchTerms searchTerms)
        {
            searchTerms.UserInput = "?search=" + searchTerms.UserInput;

            HttpResponseMessage response = client.GetAsync(searchTerms.UserInput).Result;

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                ViewBag.Message = response.Content.ReadAsStringAsync();

            }
            else
            {
                ViewBag.Message = ("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return View();
        }
    }
}
