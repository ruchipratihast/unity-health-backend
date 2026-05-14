using FluentValidation;
using UnityHealth.Models.Request.Auth;

namespace UnityHealth.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator() { 
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);
            RuleFor(x => x.FullName)
                .NotEmpty();
            RuleFor(x => x.Otp)
                .NotEmpty()
                .Length(6);
           RuleFor(x => x.Role)
                .IsInEnum();
        }
    }
}
