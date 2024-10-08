using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class CaptureRequestViewModel
    {
        [JsonPropertyName("transactionId")]
        public required string TransactionId { get; set; }

        [JsonPropertyName("clientReferenceInformationCode")]
        public required string ClientReferenceInformationCode { get; set; }

        [JsonPropertyName("orderInformation")]
        public required OrderInformation OrderInformation { get; set; }

        [JsonPropertyName("cybersourceConfiguration")]
        public required CybersourceConfiguration CybersourceConfiguration { get; set; }
    }
}
