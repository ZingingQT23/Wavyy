using System.Collections.Generic;
using Wavyy.Models.Games.Child_Objects;

namespace Wavyy.Models.Games
{
    public class Game
    {
        public int ID { get; set; }
        public DbId DbId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Storyline { get; set; }
        public Rating Esrb { get; set; }
        public Rating Pegi { get; set; }
        //public int FirstReleaseDate { get; set; }
        public GameImage Cover { get; set; }
        public List<int> Platforms { get; set; }
        public List<GameImage> Screenshots { get; set; }
        public List<GameImage> Artworks { get; set; }
        public List<int> GenreIds { get; set; }
        public List<int> DeveloperIds { get; set; }
        public List<int> PublisherIds { get; set; }
        public List<int> UserCollectionIds { get; set; }


        public Game() { }

        public Game(AddGameViewModel addGameViewModel)
        {
            DbId = new DbId(addGameViewModel.DbId);
            Name = addGameViewModel.Name;
            Slug = addGameViewModel.Slug;
            Summary = addGameViewModel.Summary;
            Cover = addGameViewModel.Cover;
            Platforms = addGameViewModel.Platforms;
            //FirstReleaseDate = addGameViewModel.FirstReleaseDate;
            Storyline = addGameViewModel.Storyline;
            Esrb = addGameViewModel.Esrb;
            Pegi = addGameViewModel.Pegi;
            Screenshots = addGameViewModel.Screenshots;
            Artworks = addGameViewModel.Artworks;
            GenreIds = addGameViewModel.GenreIds;
            DeveloperIds = addGameViewModel.DeveloperIds;
            PublisherIds = addGameViewModel.PublisherIds;
          
            if (Cover == null)
            {
                Cover = new GameImage();
                Cover.Url = "";
            }
        }

    }
}
