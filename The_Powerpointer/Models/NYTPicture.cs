using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace The_Powerpointer.Models
{
    public class NYTPicture
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("subtype")]
        public string Subtype { get; set; }
    }
}
