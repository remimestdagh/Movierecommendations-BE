using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Data
{
    public class MockObject
    {
        [JsonProperty("titleImage")]
        public string titleImage { get; set; }
        [JsonProperty("titel")]
        public string titel { get; set; }
        [JsonProperty("score")]
        public string score { get; set; }
        [JsonProperty("stars")]
        public string stars { get; set; }
        [JsonProperty("genres")]
        public string genres { get; set; }
        [JsonProperty("runtime")]
        public string runtime { get; set; }
        [JsonProperty("year")]
        public string year { get; set; }
        [JsonProperty("imdbID")]
        public string imdbID { get; set; }
        [JsonProperty("id")]
        public int id { get; set; }
    }
}
