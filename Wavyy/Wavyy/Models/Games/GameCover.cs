using Newtonsoft.Json;

namespace Wavyy.Models.Games
{
    public class GameCover
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "cloudinary_id")]
        public string CloudinaryId { get; set; }
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }
    }
}
