using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace Wavyy.Models.Games
{
    [JsonObject]
    public class DbId : IEnumerable<int>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        public DbId(int id) { Id = id; }

        public IEnumerator<int> GetEnumerator()
        {
            yield return Id;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetEnumerator();
        }
    }
}
