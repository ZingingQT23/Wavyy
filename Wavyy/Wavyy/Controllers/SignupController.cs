using Wavyy.Models;
using Wavyy.ViewModels;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Wavyy.Controllers
{
    public class SignupController : Controller
    {
        private WavyyDbContext context;

        public SignupController(WavyyDbContext dbContext)
        {
            context = dbContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(NewUserViewModel newUserViewModel)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }
    }
}