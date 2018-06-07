using System.Collections.Generic;

namespace Wavyy.Models.Games
{
    public class GameViewModel : AddGameViewModel
    {
        public int GameID { get; set; }
        public string UserID { get; set; }
        public int PlatformId { get; set; }
        public int VersionId { get; set; }

        public GameViewModel() { }

        public GameViewModel(UserGame userGame)
        {
            GameID = userGame.GameID;
            UserID = userGame.UserID;
            PlatformId = userGame.PlatformId;
            VersionId = userGame.VersionId;
        }

        public GameViewModel(AddGameViewModel addGameViewModel)
        {
            Name = addGameViewModel.Name;
            Slug = addGameViewModel.Slug;
            Summary = addGameViewModel.Summary;
            Storyline = addGameViewModel.Storyline;
            Cover = addGameViewModel.Cover;
            Artworks = addGameViewModel.Artworks;
            Screenshots = addGameViewModel.Screenshots;

        }
    }
}
