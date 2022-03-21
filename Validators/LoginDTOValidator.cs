using System.Text.RegularExpressions;
using FluentValidation;
using Minder.DTO;

namespace Minder.Validators
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresi boş geçilemez.")
                     .EmailAddress().WithMessage("Geçersiz mail adresi.");
            
            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifrenizi giriniz")
            .Length(8, 20).WithMessage("Şifreniz en az 8, en fazla 20 karakterden oluşabilir.");
        }
    }
}