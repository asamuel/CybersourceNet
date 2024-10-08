using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class PaymentInformationCard
    {
        [JsonPropertyName("cardNumber")]
        public required string CardNumber { get; set; }

        [JsonPropertyName("cardExpirationMonth")]
        public required string CardExpirationMonth { get; set; }

        [JsonPropertyName("cardExpirationYear")]
        public required string CardExpirationYear { get; set; }
    }
}
