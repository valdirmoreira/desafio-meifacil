using FluentValidation;
using MeiFacil.Payment.Application.ViewModels.Entry;

namespace MeiFacil.Payment.Application.Validators.Entry
{
    public class EntryViewModelValidator : AbstractValidator<EntryViewModel>
    {
        public EntryViewModelValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O campo id é obrigatório.");
        }
    }
}
