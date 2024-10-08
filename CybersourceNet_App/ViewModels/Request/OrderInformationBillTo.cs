using System.Text.Json.Serialization;

namespace CybersourceNet_App.ViewModels.Request
{
    public class OrderInformationBillTo
    {
        [JsonPropertyName("firstName")]
        public required string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public required string LastName { get; set; }

        [JsonPropertyName("address1")]
        public required string Address1 { get; set; }

        [JsonPropertyName("locality")]
        public required string Locality { get; set; }

        [JsonPropertyName("administrativeArea")]
        public required string AdministrativeArea { get; set; }

        [JsonPropertyName("postalCode")]
        public required string PostalCode { get; set; }

        [JsonPropertyName("country")]
        public required string Country { get; set; }

        [JsonPropertyName("email")]
        public required string Email { get; set; }

        [JsonPropertyName("phoneNumber")]
        public required string PhoneNumber { get; set; }
    }
}