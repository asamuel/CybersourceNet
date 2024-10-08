using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class CybersourceConfiguration
    {
        [JsonPropertyName("authenticationType")]
        public string AuthenticationType { get; set; } = "HTTP_SIGNATURE";

        [JsonPropertyName("merchantID")]
        public required string MerchantID { get; set; }

        [JsonPropertyName("merchantKeyId")]
        public required string MerchantKeyId { get; set; }

        [JsonPropertyName("merchantsecretKey")]
        public required string MerchantsecretKey { get; set; }

        [JsonPropertyName("useMetaKey")]
        public required string UseMetaKey { get; set; } = "false";

        [JsonPropertyName("enableClientCert")]
        public required string EnableClientCert { get; set; } = "false";

        [JsonPropertyName("runEnvironment")]
        public required string RunEnvironment { get; set; }
    }
}

