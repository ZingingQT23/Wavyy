using Newtonsoft.Json;

namespace Wavyy.Models.Games
{
    [JsonObject]
    public class GameImage
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public string Type { get; set; }

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
