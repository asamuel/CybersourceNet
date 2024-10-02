using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class CreateSearchRequestViewModel
    {
        [JsonPropertyName("save")]
        public bool Save { get; set; } = false;

        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }

        [JsonPropertyName("query")]
        public string Query { get; set; }

        [JsonPropertyName("offset")]
        public int? Offset { get; set; } = 0;

        [JsonPropertyName("limit")]
        public int? Limit { get; set; } = 10;

        [JsonPropertyName("sort")]
        public string? Sort { get; set; }

        [JsonPropertyName("cybersourceConfiguration")]
        public CybersourceConfiguration CybersourceConfiguration { get; set; }
    }
}
