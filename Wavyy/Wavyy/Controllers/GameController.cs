using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.Identity;
using System.Linq;
using Wavyy.Data;
using Wavyy.Models;
using Wavyy.Models.Games;
using System;

namespace Wavyy.Controllers
{
    public class GameController : Controller
    {
        private readonly WavyyDbContext context;

        public GameController(WavyyDbContext dbContext)
        {
            context = dbContext;
        }


    
        public IActionResult MyGames()
        {
            //TODO: Search context for the active user and its UserGames list and pass it into the view

            return View();
        }

        [HttpPost]
        public IActionResult AddToMyGames(int gameId)
        {
            string currentUserId = User.Identity.GetUserId();

            //TODO: if null redirect to login page
            int userId = Int32.Parse(currentUserId);
            ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == currentUserId);

            UserGame newUserGame = new UserGame();
            newUserGame.GameID = gameId;
            newUserGame.UserID = userId;

            context.UserGames.Add(newUserGame);
            context.SaveChanges();

            return View("/Game/MyGames");
        }
    }
}