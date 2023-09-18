using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class CaptureRequestViewModel
    {
        [JsonPropertyName("transactionId")]
        public string TransactionId { get; set; }

        [JsonPropertyName("clientReferenceInformationCode")]
        public string ClientReferenceInformationCode { get; set; }

        [JsonPropertyName("orderInformation")]
        public OrderInformation OrderInformation { get; set; }

        [JsonPropertyName("cybersourceConfiguration")]
        public CybersourceConfiguration CybersourceConfiguration { get; set; }
    }
}
