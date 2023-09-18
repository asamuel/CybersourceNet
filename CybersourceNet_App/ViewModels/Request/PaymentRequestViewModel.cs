using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class PaymentRequestViewModel
    {

        [JsonPropertyName("clientReferenceInformationCode")]
        public string ClientReferenceInformationCode { get; set; }

        [JsonPropertyName("captureTrueForProcessPayment")]
        public Boolean CaptureTrueForProcessPayment { get; set; } = false;

        [JsonPropertyName("paymentInformationCard")]
        public PaymentInformationCard PaymentInformationCard { get; set; }

        [JsonPropertyName("orderInformation")]
        public OrderInformation OrderInformation { get; set; }

        [JsonPropertyName("orderInformationBillTo")]
        public OrderInformationBillTo OrderInformationBillTo { get; set; }

        [JsonPropertyName("cybersourceConfiguration")]
        public CybersourceConfiguration CybersourceConfiguration { get; set; }
    }
}
