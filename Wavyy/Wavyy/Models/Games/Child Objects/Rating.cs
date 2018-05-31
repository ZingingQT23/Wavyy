using Newtonsoft.Json;

namespace Wavyy.Models.Games.Child_Objects
{
    [JsonObject]
    public class Rating
    {
        [JsonProperty(PropertyName = "rating")]
        public int RatingId { get; set; }
        [JsonProperty(PropertyName = "synopsis")]
        public string Synopsis { get; set; }
    }
}
