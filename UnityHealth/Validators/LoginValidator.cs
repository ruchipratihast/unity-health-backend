using FluentValidation;
using UnityHealth.Models.Request.Auth;

namespace UnityHealth.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
     public LoginValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
