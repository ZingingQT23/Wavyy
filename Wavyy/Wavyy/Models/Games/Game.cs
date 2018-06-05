namespace Wavyy.Models.Games
{
    public class Game
    {
        public int ID { get; set; }
        public int DbId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Storyline { get; set; }
        public int Esrb { get; set; }
        public int Pegi { get; set; }
        public string FirstReleaseDate { get; set; }

        public Game() { }

        public Game(AddGameViewModel addGameViewModel)
        {
            DbId = addGameViewModel.DbId;
            Name = addGameViewModel.Name;
            Slug = addGameViewModel.Slug;
            Summary = addGameViewModel.Summary;
            FirstReleaseDate = addGameViewModel.FirstReleaseDate;
            Storyline = addGameViewModel.Storyline;
            //Esrb = addGameViewModel.Esrb.RatingId;
            //Pegi = addGameViewModel.Pegi.RatingId;
        }

    }
}
