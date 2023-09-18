using CybersourceNet_App.ViewModels.Auth;
using FluentValidation;

namespace CybersourceNet_Api.Validators
{
    public class UserLoginRequestValidator : AbstractValidator<UserLoginRequestViewModel>
    {
        public UserLoginRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("La Propiedad {PropertyName} es requerida");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("La Propiedad {PropertyName} es requerida");
        }
    }
}
