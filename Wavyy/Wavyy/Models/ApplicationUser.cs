using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Wavyy.Models.Games;

namespace Wavyy.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Collection> UserCollections { get; set; }
    }
}
