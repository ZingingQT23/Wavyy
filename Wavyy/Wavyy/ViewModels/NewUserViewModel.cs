using System.ComponentModel.DataAnnotations;
using Wavyy.Models;

namespace Wavyy.ViewModels
{
    public class NewUserViewModel : User
    {
        [Required]
        [Display(Name = "Verify Password")]
        [Compare("Password")]
        public string VPassword { get; set; }
        [Required]
        [Display(Name = "Verify Email")]
        [Compare("Email")]
        public string VEmail { get; set; }
    }
}