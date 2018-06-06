namespace Wavyy.Models.Games
{
    public class UserGame
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public string UserID { get; set; }
        public int PlatformId { get; set; }
        public int VersionId { get; set; }

        public UserGame() { }

    }
}
