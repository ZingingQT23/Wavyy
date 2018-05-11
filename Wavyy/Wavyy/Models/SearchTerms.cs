using System.ComponentModel.DataAnnotations;

namespace Wavyy.Models
{
    public class SearchTerms
    {
        [Required]
        public string UserInput { get; set; }
    }
}
