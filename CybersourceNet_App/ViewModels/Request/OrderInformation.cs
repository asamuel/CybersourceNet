using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class OrderInformation
    {
        [JsonPropertyName("totalAmount")]
        public string TotalAmount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }
}
