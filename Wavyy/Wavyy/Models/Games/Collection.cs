using System.Collections.Generic;

namespace Wavyy.Models.Games
{
    public class Collection
    {
        public int ID { get; set; }
        public List<UserGame> Games { get; set; }
        public int ApplicationUserID { get; set; }
    }
}
