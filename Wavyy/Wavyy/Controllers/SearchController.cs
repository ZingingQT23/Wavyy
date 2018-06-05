using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Wavyy.Data;
using Wavyy.Models;
using Wavyy.Models.Games;

namespace Wavyy.Controllers
{
    public class SearchController : Controller
    {
        static HttpClient client = new HttpClient();

        private const string URI = "https://api-2445582011268.apicast.io/";
        private const string byName = "/games/?search={0}";
        private const string byId = "/games/{0}?fields=name,id,slug,summary,cover,platforms,esrb,pegi,storyline,first_release_date,screenshots,artworks,genres,developers,publishers";
        private const string forVersions = "/game_versions/?fields=games.name&filter[games][exists]=1&filter[game][eq]={0}&expand=games";

        private readonly WavyyDbContext context;

        public SearchController(WavyyDbContext dbContext)
        {
            context = dbContext;
        }

        private static void CheckClient()
        {
            if (client.BaseAddress == null)
            {
                
                client.BaseAddress = new Uri(URI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("user-key", System.IO.File.ReadAllText(@"C:\Users\Dylan\Wavyy\uK.txt").ToString());
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

        public async Task<List<Game>> PopulateGames(List<DbId> dbIds)
        {
            List<Game> searchResults = new List<Game>();

            //TODO: check if items with those DbIds exist already in local db, if yes, add to searchResults, for the rest:
            foreach (DbId dbId in dbIds)
            {
                string json = await MakeRequest(string.Format(byId, dbId.Id));

                List<AddGameViewModel> addGameViewModel = JsonConvert.DeserializeObject<List<AddGameViewModel>>(json);

                //TODO: Create PlatformGames, PublisherGames, GenreGames, DeveloperGames, GameImages and add them to the dbcontext

                Game newGame = new Game(addGameViewModel[0]);

                searchResults.Add(newGame);

                context.Games.Add(newGame);
            }

            context.SaveChanges();

            return searchResults;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ByName(SearchTerms searchTerms)
        {
            CheckClient();

            string json = await MakeRequest(string.Format(byName, searchTerms.UserInput));

            List<DbId> dbIds = JsonConvert.DeserializeObject<List<DbId>>(json);

            List<Game> searchResults = await PopulateGames(dbIds);

            TempData["SearchResults"] = searchResults;

            return View("Index");
        }

        public async Task<IActionResult> SingleGame(int id)
        {
            //TODO: Convert these requests to query the dbcontext instead of the api

            string json = await MakeRequest(string.Format(byId, id));

            List<AddGameViewModel> addGameViewModel = JsonConvert.DeserializeObject<List<AddGameViewModel>>(json);

            Game thisGame = new Game(addGameViewModel[0]);

            TempData["ThisGame"] = thisGame;

            return View();
        }
    }
}
