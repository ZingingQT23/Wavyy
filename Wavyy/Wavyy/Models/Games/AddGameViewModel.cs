using Newtonsoft.Json;
using System.Collections.Generic;
using Wavyy.Models.Games.Child_Objects;

namespace Wavyy.Models.Games
{
    [JsonObject]
    public class AddGameViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int DbId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }
        [JsonProperty(PropertyName = "cover")]
        public GameImage Cover { get; set; }
        [JsonProperty(PropertyName = "platforms")]
        public List<int> Platforms { get; set; }
        //[JsonProperty(PropertyName = "first_release_date")]
        //public int FirstReleaseDate { get; set; }
        [JsonProperty(PropertyName = "storyline")]
        public string Storyline { get; set; }
        [JsonProperty(PropertyName = "esrb")]
        public Rating Esrb { get; set; }
        [JsonProperty(PropertyName = "pegi")]
        public Rating Pegi { get; set; }
        [JsonProperty(PropertyName = "screenshots")]
        public List<GameImage> Screenshots { get; set; }
        [JsonProperty(PropertyName = "artworks")]
        public List<GameImage> Artworks { get; set; }
        [JsonProperty(PropertyName = "genres")]
        public List<int> GenreIds { get; set; }
        [JsonProperty(PropertyName = "developers")]
        public List<int> DeveloperIds { get; set; }
        [JsonProperty(PropertyName = "publishers")]
        public List<int> PublisherIds { get; set; }
    }
}
