using System.Collections.Generic;

namespace Wavyy.Models.Games
{
    public class Collection
    {
        public int ID { get; set; }
        public List<UserGame> UserGames { get; set; }
    }
}
