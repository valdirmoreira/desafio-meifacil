using FluentValidation;
using MeiFacil.Payment.Application.ViewModels.CheckingAccount;

namespace MeiFacil.Payment.Application.Validators.CheckingAccount
{
    public class CheckingAccountViewModelValidator : AbstractValidator<CheckingAccountViewModel>
    {
        public CheckingAccountViewModelValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O campo id é obrigatório.");
        }
    }
}
