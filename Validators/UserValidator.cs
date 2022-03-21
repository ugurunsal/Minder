using System.Text.RegularExpressions;
using FluentValidation;
using Minder.Model;

namespace Minder.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
            .Must(IsLetter).WithMessage("Ad alanı sadece harf içermek zorundadır")
            .NotEmpty().WithMessage("Ad alanı boş geçilemez")
            .MinimumLength(3).WithMessage("Ad alanı 3 karakterden kısa olamaz");

            RuleFor(x => x.LastName)
            .Must(IsLetter).WithMessage("Soyad alanı sadece harf içermek zorundadır")
            .NotEmpty().WithMessage("Soyad alanı boş geçilemez")
            .MinimumLength(2).WithMessage("Soyad alanı 2 karakterden kısa olamaz");

            RuleFor(x => x.Gender)
            .Must(x => x.Equals("Male") || x.Equals("Female")).WithMessage("Cinsiyet Male veya Female olmak zorundadır");

            RuleFor(x => x.AccountId)
            .NotEmpty().WithMessage("AccountId alanı boş geçilemez.")
            .GreaterThan(0).WithMessage("AccountId alanı 0'dan büyük olmalıdır!");


            RuleFor(p => p.BirthDate)
            .NotEmpty().WithMessage("Doğum tarihi boş geçilemez.")
            .Must(BeAValidAge).WithMessage("Geçersiz doğum tarihi.");
        }

        private bool IsLetter(string arg)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            return regex.IsMatch(arg);
        }

        private bool BeAValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if (dobYear <= currentYear && dobYear > (currentYear - 120))
            {
                return true;
            }

            return false;
        }
    }
}