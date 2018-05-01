using System.ComponentModel.DataAnnotations;
using Wavyy.Models;

namespace Wavyy.ViewModels
{
    public class NewUserViewModel : User
    {
        [Compare("Password")]
        public string VPassword { get; set; }
        [Compare("Email")]
        public string VEmail { get; set; }
    }
}