using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Wavyy.Models;
using Wavyy.Models.Games;

namespace Wavyy.Controllers
{
    public class SearchController : Controller
    {
        static HttpClient client = new HttpClient();

        private const string URI = "https://api-2445582011268.apicast.io/";
        private const string userKey = "befc5535687e5de93cfd50d93bf10669";

        private static void CheckClient()
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("user-key", userKey);
            }
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
        public async Task<IActionResult> ByName(SearchTerms searchTerms)
        {
            CheckClient();

            searchTerms.UserInput = "games/?search=" + searchTerms.UserInput;

            ViewBag.Message = await MakeRequest(searchTerms.UserInput);

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ById(SearchTerms searchTerms)
        {
            CheckClient();

            string request = "/games/" + searchTerms.UserInput + "?fields=name,id,slug,summary,cover,platforms";

            string response = await MakeRequest(request);

            List<AddGameViewModel> addGameViewModel = JsonConvert.DeserializeObject<List<AddGameViewModel>>(response);

            ViewBag.Message = response;

            return View("Index");
        }

    }
}
