using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class Film2
    {
        [JsonProperty("titel")]
        public string titel { get; set; }
        [JsonProperty("score")]
        public string score { get; set; }
        [JsonProperty("stars")]
        public string stars { get; set; }
        [JsonProperty("genres")]
        public string genres { get; set; }
        [JsonProperty("titleImage")]
        public string titleImage { get; set; }
        [JsonProperty("runtime")]
        public string runtime { get; set; }
        [JsonProperty("year")]
        public string year { get; set; }
    }
}
