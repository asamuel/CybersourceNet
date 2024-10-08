using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class ReversalRequestViewModel
    {
        [JsonPropertyName("transactionId")]
        public required string TransactionId { get; set; }

        [JsonPropertyName("clientReferenceInformationCode")]
        public required string ClientReferenceInformationCode { get; set; }

        [JsonPropertyName("reversalInformationReason")]
        public required string ReversalInformationReason { get; set; }

        [JsonPropertyName("orderInformation")]
        public required OrderInformation OrderInformation { get; set; }

        [JsonPropertyName("cybersourceConfiguration")]
        public required CybersourceConfiguration CybersourceConfiguration { get; set; }
    }
}
