using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class OrderInformationBillTo
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("address1")]
        public string Address1 { get; set; }

        [JsonPropertyName("locality")]
        public string Locality { get; set; }

        [JsonPropertyName("administrativeArea")]
        public string AdministrativeArea { get; set; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}