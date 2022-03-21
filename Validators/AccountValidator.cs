using System.Text.RegularExpressions;
using FluentValidation;
using Minder.Model;

namespace Minder.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresi boş geçilemez.")
                     .EmailAddress().WithMessage("Geçersiz mail adresi.");
            
            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifrenizi giriniz")
            .Length(8, 20).WithMessage("Şifreniz en az 8, en fazla 20 karakterden oluşabilir.");

            RuleFor(x => x.IsVisible)
            .NotEmpty().WithMessage("IsVisible alanı boş geçilemez")
            .Must(x => x.Equals(true) || x.Equals(false)).WithMessage("Blocked alanı \"true\" ya da \"false\" olmalıdır.");
            
            RuleFor(x => x.IsBlocked)
            .NotEmpty().WithMessage("IsBlocked alanı boş geçilemez")
            .Must(x => x.Equals(true) || x.Equals(false)).WithMessage("Blocked alanı \"true\" ya da \"false\" olmalıdır.");

            RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId alanı boş geçilemez.")
            .GreaterThan(0).WithMessage("UserId alanı 0'dan büyük olmalıdır!");
        }
    }
}