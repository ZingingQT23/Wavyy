using Microsoft.AspNetCore.Mvc;
using Wavyy.Data;

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


    }
}