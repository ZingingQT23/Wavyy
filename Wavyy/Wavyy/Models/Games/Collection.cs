using System.Collections.Generic;

namespace Wavyy.Models.Games
{
    public class Collection
    {
        public int ID { get; set; }
        public List<Game> Games { get; set; }
        public int OwnerId { get; set; }
    }
}
