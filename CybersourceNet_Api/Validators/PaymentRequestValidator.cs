using CybersourceNet_App.ViewModels.Request;
using FluentValidation;

namespace CybersourceNet_Api.Validators
{
    public class PaymentRequestValidator : AbstractValidator<PaymentRequestViewModel>
    {
        public PaymentRequestValidator()
        {
            RuleFor(x => x.ClientReferenceInformationCode)
                .NotEmpty()
                .WithMessage("La Propiedad {PropertyName} es requerida");

            RuleFor(x => x.CaptureTrueForProcessPayment)
                .NotNull()
                .WithMessage("La Propiedad {PropertyName} es requerida");

            RuleFor(x => x.PaymentInformationCard)
                .NotEmpty()
                .WithMessage("La Propiedad {PropertyName} es requerida")
                .ChildRules(cred =>
                {
                    cred.RuleFor(x => x.CardNumber)
                        .NotEmpty()
                        .WithName("PaymentInformationCard => CardNumber")
                        .WithMessage("La Propiedad {PropertyName} es requerida");

                    cred.RuleFor(x => x.CardExpirationMonth)
                        .NotEmpty()
                        .WithName("PaymentInformationCard => CardExpirationMonth")
                        .WithMessage("La Propiedad {PropertyName} es requerida");

                    cred.RuleFor(x => x.CardExpirationYear)
                       .NotEmpty()
                       .WithName("PaymentInformationCard => CardExpirationYear")
                       .WithMessage("La Propiedad {PropertyName} es requerida");
                });

            RuleFor(x => x.OrderInformation)
                .NotEmpty()
                .WithMessage("La Propiedad {PropertyName} es requerida")
                .ChildRules(cred =>
                {
                    cred.RuleFor(x => x.TotalAmount)
                        .NotEmpty()
                        .WithName("OrderInformation => TotalAmount")
                        .WithMessage("La Propiedad {PropertyName} es requerida");

                    cred.RuleFor(x => x.Currency)
                        .NotEmpty()
                        .WithName("PaymentInformationCard => Currency")
                        .WithMessage("La Propiedad {PropertyName} es requerida");
                });

            RuleFor(x => x.OrderInformationBillTo)
              .NotEmpty()
              .WithMessage("La Propiedad {PropertyName} es requerida")
              .ChildRules(cred =>
              {
                  cred.RuleFor(x => x.FirstName)
                      .NotEmpty()
                      .WithName("OrderInformationBillTo => FirstName")
                      .WithMessage("La Propiedad {PropertyName} es requerida");

                  cred.RuleFor(x => x.LastName)
                      .NotEmpty()
                      .WithName("OrderInformationBillTo => LastName")
                      .WithMessage("La Propiedad {PropertyName} es requerida");

                  cred.RuleFor(x => x.Address1)
                     .NotEmpty()
                     .WithName("OrderInformationBillTo => Address1")
                     .WithMessage("La Propiedad {PropertyName} es requerida");

                  cred.RuleFor(x => x.Locality)
                     .NotEmpty()
                     .WithName("OrderInformationBillTo => Locality")
                     .WithMessage("La Propiedad {PropertyName} es requerida");

                  cred.RuleFor(x => x.PostalCode)
                     .NotEmpty()
                     .WithName("OrderInformationBillTo => PostalCode")
                     .WithMessage("La Propiedad {PropertyName} es requerida");

                  cred.RuleFor(x => x.Country)
                     .NotEmpty()
                     .WithName("OrderInformationBillTo => Country")
                     .WithMessage("La Propiedad {PropertyName} es requerida");

                  cred.RuleFor(x => x.Email)
                     .NotEmpty()
                     .WithName("OrderInformationBillTo => Email")
                     .WithMessage("La Propiedad {PropertyName} es requerida");

                  cred.RuleFor(x => x.PhoneNumber)
                   .NotEmpty()
                   .WithName("OrderInformationBillTo => PhoneNumber")
                   .WithMessage("La Propiedad {PropertyName} es requerida");
              });

            RuleFor(x => x.CybersourceConfiguration)
                .NotEmpty()
                .WithMessage("La Propiedad {PropertyName} es requerida")
                .ChildRules(cred =>
                {
                    cred.RuleFor(x => x.MerchantID)
                        .NotEmpty()
                        .WithName("CybersourceConfiguration => MerchantID")
                        .WithMessage("La Propiedad {PropertyName} es requerida");

                    cred.RuleFor(x => x.MerchantKeyId)
                        .NotEmpty()
                        .WithName("CybersourceConfiguration => MerchantKeyId")
                        .WithMessage("La Propiedad {PropertyName} es requerida");

                    cred.RuleFor(x => x.MerchantsecretKey)
                        .NotEmpty()
                        .WithName("CybersourceConfiguration => MerchantsecretKey")
                        .WithMessage("La Propiedad {PropertyName} es requerida");

                    cred.RuleFor(x => x.RunEnvironment)
                        .NotEmpty()
                        .WithName("CybersourceConfiguration => RunEnvironment")
                        .WithMessage("La Propiedad {PropertyName} es requerida");
                });
        }
    }
}
