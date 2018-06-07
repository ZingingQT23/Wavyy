using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.Identity;
using System.Linq;
using Wavyy.Data;
using Wavyy.Models;
using Wavyy.Models.Games;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Wavyy.Controllers
{
    public class GameController : Controller
    {
        private readonly WavyyDbContext context;

        public GameController(WavyyDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult SingleGame(int id)
        {
            Game thisGame = context.Games.Where(x => x.ID == id).FirstOrDefault<Game>();

            TempData["ThisGame"] = thisGame;

            return View();
        }

        public async Task<IActionResult> MyGames()
        {
            string userId = User.Identity.GetUserId();

            List<UserGame> userGames = context.UserGames.Where(x => x.UserID == userId).ToList();

            List<GameViewModel> myGames = new List<GameViewModel>();

            foreach (UserGame game in userGames)
            {
                GameViewModel userGameViewModel = new GameViewModel(game);

                //var cover = context.GameImages.Where(x => x.GameID == userGameViewModel.GameID).Where(x => x.Type == "cover").FirstOrDefault().Url;

                //if (cover != null)
                //{
                //    string coverUrl = cover.ToString();
                //    userGameViewModel.CoverUrl = coverUrl;
                //} else
                //{
                //    userGameViewModel.CoverUrl = "";
                //}

                myGames.Add(userGameViewModel);
            }

            TempData["myGames"] = myGames;

            return View();
        }

        [HttpPost]
        public IActionResult AddToMyGames(int gameId)
        {
            string userId = User.Identity.GetUserId();

            if (userId == null)
            {
                return Redirect("/Account/Login");
            }

            ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == userId);

            UserGame newUserGame = new UserGame();
            newUserGame.GameID = gameId;
            newUserGame.UserID = userId;

            context.UserGames.Add(newUserGame);
            context.SaveChanges();

            return Redirect("/Home/Index");
        }
    }
}