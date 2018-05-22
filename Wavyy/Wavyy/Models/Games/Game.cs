using System.Collections.Generic;

namespace Wavyy.Models.Games
{
    public class Game
    {
        public int ID { get; set; }
        public DbId DbId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public GameCover Cover { get; set; }
        public List<int> Platforms { get; set; }

        public Game() { }

        public Game(AddGameViewModel addGameViewModel)
        {
            DbId = new DbId(addGameViewModel.DbId);
            Name = addGameViewModel.Name;
            Slug = addGameViewModel.Slug;
            Summary = addGameViewModel.Summary;
            Cover = addGameViewModel.Cover;
            Platforms = addGameViewModel.Platforms;
        }

    }
}
