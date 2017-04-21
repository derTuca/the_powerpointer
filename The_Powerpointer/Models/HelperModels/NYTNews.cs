using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using The_Powerpointer.Data;

namespace The_Powerpointer.Models.HelperModels
{   
    [JsonConverter(typeof(JsonPathConverter))]
    // ReSharper disable once InconsistentNaming
    public class NYTNews 
    {
        [JsonProperty("web_url")]
        public string Url { get; set; }

        [JsonProperty("snippet")]
        public string Description { get; set; }

       
        [JsonProperty("headline.main")]
        public string Headline { get; set; }

        public string ImageUrl
        {
            get
            {
                if (Enumerable.Any(Media))
                {
                    var pic = Enumerable.FirstOrDefault(Media, p => p.Subtype == "wide");
                    if (pic == null) return Enumerable.First(Media).Url;
                    return pic.Url;
                    
                }
                return "";
            }
            set => ImageUrl = value;
        }

        [JsonProperty("multimedia")]
        public List<NYTPicture> Media { get; set; }

        [JsonProperty("pub_date")]
        public DateTime DatePublished { get; set; }
    }
}
