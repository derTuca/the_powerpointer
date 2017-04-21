using Newtonsoft.Json;

namespace The_Powerpointer.Models.HelperModels
{
    public class NYTPicture
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("subtype")]
        public string Subtype { get; set; }
    }
}
