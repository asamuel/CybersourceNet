using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class OrderInformation
    {
        [JsonPropertyName("totalAmount")]
        public required string TotalAmount { get; set; }

        [JsonPropertyName("currency")]
        public required  string Currency { get; set; }
    }
}
