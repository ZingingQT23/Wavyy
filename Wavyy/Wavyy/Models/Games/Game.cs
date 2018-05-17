using System.Collections.Generic;

namespace Wavyy.Models.Games
{
    public class Game
    {
        public int ID { get; set; }
        public int DbId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public GameCover Cover { get; set; }
        public List<int> Platforms { get; set; }
    }
}
