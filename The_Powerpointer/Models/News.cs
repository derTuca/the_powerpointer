using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace The_Powerpointer.Models
{
    public class News
    {
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("publishedAt")]
        public DateTime DatePublished { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("urlToImage")]
        public string ImageSource { get; set; }
    }
}
