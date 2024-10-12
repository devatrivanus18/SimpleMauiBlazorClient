using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SampleAPIMauiBlazorClient.Models
{
    public class MReleaseDates
    {
        [JsonPropertyName("Japan")]
        public string Japan { get; set; }
        [JsonPropertyName("NorthAmerica")]
        public string NorthAmerica { get; set; }
        [JsonPropertyName("Europe")]
        public string Europe { get; set; }
        [JsonPropertyName("Australia")]
        public string Australia { get; set; }
    }
}
