using CybersourceNet_App.ViewModels.Request;
using FluentValidation;

namespace CybersourceNet_Api.Validators
{
    public class ReversalRequestValidator : AbstractValidator<ReversalRequestViewModel>
    {
        public ReversalRequestValidator()
        {
            RuleFor(x => x.ClientReferenceInformationCode)
                .NotEmpty()
                .WithMessage("La Propiedad {PropertyName} es requerida");

            RuleFor(x => x.TransactionId)
                .NotEmpty()
                .WithMessage("La Propiedad {PropertyName} es requerida");

            RuleFor(x => x.ReversalInformationReason)
                .NotEmpty()
                .WithMessage("La Propiedad {PropertyName} es requerida");

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
