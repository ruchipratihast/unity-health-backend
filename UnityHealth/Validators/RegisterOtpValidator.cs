using FluentValidation;
using UnityHealth.Models.Request.Auth;

namespace UnityHealth.Validators
{
    public class RegisterOtpValidator : AbstractValidator<RegisterOtpRequest>
    {
        public RegisterOtpValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
