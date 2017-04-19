using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using The_Powerpointer.Data;

namespace The_Powerpointer.Models
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
                if (Media.Any())
                {
                    var pic = Media.FirstOrDefault(p => p.Subtype == "wide");
                    if (pic == null) return Media.First().Url;
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
