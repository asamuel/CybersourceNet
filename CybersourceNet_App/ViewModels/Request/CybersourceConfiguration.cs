using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class CybersourceConfiguration
    {
        [JsonPropertyName("authenticationType")]
        public string AuthenticationType { get; set; } = "HTTP_SIGNATURE";

        [JsonPropertyName("merchantID")]
        public string MerchantID { get; set; }

        [JsonPropertyName("merchantKeyId")]
        public string MerchantKeyId { get; set; }

        [JsonPropertyName("merchantsecretKey")]
        public string MerchantsecretKey { get; set; }

        [JsonPropertyName("useMetaKey")]
        public string UseMetaKey { get; set; } = "false";

        [JsonPropertyName("enableClientCert")]
        public string EnableClientCert { get; set; } = "false";

        [JsonPropertyName("runEnvironment")]
        public string RunEnvironment { get; set; }
    }
}

