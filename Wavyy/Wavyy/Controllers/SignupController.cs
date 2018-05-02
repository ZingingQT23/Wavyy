using Wavyy.Models;
using Wavyy.Data;
using Wavyy.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Wavyy.Controllers
{
    public class SignupController : Controller
    {
        private WavyyDbContext context;

        public SignupController(WavyyDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(NewUserViewModel newUserViewModel)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User();
                newUser.Username = newUserViewModel.Username;
                newUser.Email = newUserViewModel.Email;
                newUser.Password = newUserViewModel.Password;

                context.Users.Add(newUser);
                context.SaveChanges();

                return Redirect("/Welcome");
            }
            return View();
        }
    }
}