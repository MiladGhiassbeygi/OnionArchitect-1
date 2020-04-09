using FluentValidation;
using OnionArchitect.Api.V1.Forms.Accounts;

namespace OnionArchitect.Api.V1.Validators.Account
{
    public class RefreshTokenFormValidator : AbstractValidator<RefreshTokenForm>
    {
        public RefreshTokenFormValidator()
        {
            RuleFor(x => x.AccessToken)
               .NotNull()
               .NotEmpty()
               .WithMessage("اکسس توکن نمی تواند بدون مقدار یا رشته خالی باشد ");
               

            RuleFor(x => x.RefreshToken)
               .NotNull()
               .NotEmpty()
               .WithMessage("رفرش توکن نمی تواند بدون مقدار یا رشته خالی  باشد ");
        }
    }
}
