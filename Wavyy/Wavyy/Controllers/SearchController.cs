using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private async void PopulateRelationships(AddGameViewModel addGameViewModel, int gameId)
        {
            if (addGameViewModel.Cover != null)
            {
                GameImage newCover = addGameViewModel.Cover;
                newCover.Type = "cover";
                newCover.GameID = gameId;
                context.GameImages.Add(newCover);
            }

            if (addGameViewModel.Artworks != null)
            {
                foreach (GameImage img in addGameViewModel.Artworks)
                {
                    GameImage newArtwork = img;
                    newArtwork.Type = "artwork";
                    newArtwork.GameID = gameId;
                    context.GameImages.Add(newArtwork);
                }
            }

            if (addGameViewModel.Screenshots != null)
            {
                foreach (GameImage img in addGameViewModel.Screenshots)
                {
                    GameImage newScreenshot = img;
                    newScreenshot.Type = "screenshot";
                    newScreenshot.GameID = gameId;
                    context.GameImages.Add(newScreenshot);
                }
            }

            //TODO: Create Platforms, PlatformGames, Publishers, PublisherGames, Genres, GenreGames, Developers, DeveloperGames, and add them to the dbcontext

            if (addGameViewModel.Platforms != null)
            {
                //TODO: Check if the platforms exist in the platforms table, if not, MakeRequest for the platform, populate it, and add it to the context
                
            }

            context.SaveChanges();
        }

        public async Task<List<Game>> PopulateGames(List<DbId> dbIds)
        {
            List<Game> searchResults = new List<Game>();

            
            foreach (DbId dbId in dbIds)
            {
                //TODO: check if items with those DbIds exist already in local db, if yes, add to searchResults, for the rest:

                string json = await MakeRequest(string.Format(byId, dbId.Id));

                List<AddGameViewModel> addGameViewModel = JsonConvert.DeserializeObject<List<AddGameViewModel>>(json);

                if (addGameViewModel[0].Cover == null)
                {
                    continue;
                }

                Game newGame = new Game(addGameViewModel[0]);

                searchResults.Add(newGame);

                context.Games.Add(newGame);

                newGame = context.Games.Where(x => x.DbId == dbId.Id).FirstOrDefault<Game>();

                PopulateRelationships(addGameViewModel[0], newGame.ID);
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


    }
}
