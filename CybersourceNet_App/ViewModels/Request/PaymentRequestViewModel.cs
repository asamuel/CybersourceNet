using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class PaymentRequestViewModel
    {

        [JsonPropertyName("clientReferenceInformationCode")]
        public required  string ClientReferenceInformationCode { get; set; }

        [JsonPropertyName("captureTrueForProcessPayment")]
        public Boolean CaptureTrueForProcessPayment { get; set; } = false;

        [JsonPropertyName("paymentInformationCard")]
        public required PaymentInformationCard PaymentInformationCard { get; set; }

        [JsonPropertyName("orderInformation")]
        public required OrderInformation OrderInformation { get; set; }

        [JsonPropertyName("orderInformationBillTo")]
        public required OrderInformationBillTo OrderInformationBillTo { get; set; }

        [JsonPropertyName("cybersourceConfiguration")]
        public required CybersourceConfiguration CybersourceConfiguration { get; set; }
    }
}
