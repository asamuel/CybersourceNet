
using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Response
{
    public class CreateSearchCodeResponse
    {
        [JsonPropertyName("rFlag")]
        public string? RFlag { get; set; }

        [JsonPropertyName("reasonCode")]
        public string? ReasonCode { get; set; }

        [JsonPropertyName("rCode")]
        public string? RCode { get; set; }
    }
    public class CreateSearchResponseViewModel : CreateSearchCodeResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("approvalCode")]
        public string? ApprovalCode { get; set; }

        [JsonPropertyName("cardSuffix")]
        public string? CardSuffix { get; set; }

        [JsonPropertyName("applications")]
        public List<Application>? ApplicationsList { get; set; }
    }

    public class Application : CreateSearchCodeResponse
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("reconciliationId")]
        public string? ReconciliationId { get; set; }

        [JsonPropertyName("rMessage")]
        public string? RMessage { get; set; }

        [JsonPropertyName("returnCode")]
        public int? ReturnCode { get; set; }
    }
}
