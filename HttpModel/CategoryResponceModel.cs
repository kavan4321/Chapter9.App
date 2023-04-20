
using Newtonsoft.Json;

namespace Chapter9.HttpModel
{
    public class CategoryResponceModel
    {
            [JsonProperty("data")]
            public List<string> Catogory { get; set; }
    }
}
