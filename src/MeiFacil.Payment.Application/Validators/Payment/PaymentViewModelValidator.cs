using FluentValidation;
using MeiFacil.Payment.Application.ViewModels.Payment;

namespace MeiFacil.Payment.Application.Validators.Payment
{
    public class PaymentViewModelValidator : AbstractValidator<PaymentViewModel>
    {
        public PaymentViewModelValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O campo id é obrigatório.");
        }
    }
}
