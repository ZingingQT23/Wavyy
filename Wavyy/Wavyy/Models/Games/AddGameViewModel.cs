using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wavyy.Models.Games
{
    public class AddGameViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }
        [JsonProperty(PropertyName = "cover")]
        public GameCover Cover { get; set; }
        [JsonProperty(PropertyName = "platforms")]
        public List<int> Platforms { get; set; }
    }
}
