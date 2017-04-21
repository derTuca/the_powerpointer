using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using The_Powerpointer.Models.Joiners;

namespace The_Powerpointer.Models.AppModels
{
    public class News
    {
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Headline { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("publishedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DatePublished { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("urlToImage")]
        public string ImageUrl { get; set; }

        public virtual ICollection<UserNews> Users { get; set; }
    }
}
