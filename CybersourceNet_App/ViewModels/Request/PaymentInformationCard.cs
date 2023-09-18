using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class PaymentInformationCard
    {
        [JsonPropertyName("cardNumber")]
        public string CardNumber { get; set; }

        [JsonPropertyName("cardExpirationMonth")]
        public string CardExpirationMonth { get; set; }

        [JsonPropertyName("cardExpirationYear")]
        public string CardExpirationYear { get; set; }
    }
}
