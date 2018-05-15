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

        private const string URI = "https://api-2445582011268.apicast.io/";
        private const string userKey = "befc5535687e5de93cfd50d93bf10669";

        private static void FormatClient()
        {
            client.BaseAddress = new Uri(URI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("user-key", userKey);
        }

        static async Task<string> MakeRequest(string input)
        {
            HttpResponseMessage response = await client.GetAsync(input);
            
            string result = string.Empty;

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                result = response.StatusCode.ToString() + response.ReasonPhrase.ToString();
                return result;
            }

            return result;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchTerms searchTerms)
        {
            if (client.BaseAddress == null)
            {
                FormatClient();
            }

            searchTerms.UserInput = "games/?search=" + searchTerms.UserInput;

            ViewBag.Message = await MakeRequest(searchTerms.UserInput);

            return View();
        }
    }
}
