using FluentValidation;
using MeiFacil.Payment.Application.ViewModels.Payment;

namespace MeiFacil.Payment.Application.Validators.Payment
{
    public class CreatePaymentViewModelValidator : AbstractValidator<CreatePaymentViewModel>
    {
        public CreatePaymentViewModelValidator()
        {
            RuleFor(c => c.Value)
                .NotEmpty()
                .WithMessage("Value field is required")
                .GreaterThan(0)
                .WithMessage("Value field is invalid");

            RuleFor(c => c.CreditAccountNumber)
                .NotEmpty()
                .WithMessage("CreditAccountNumber field is required");

            RuleFor(c => c.DebitAccountNumber)
                .NotEmpty()
                .WithMessage("DebitAccountNumber field is required");

            RuleFor(c => c.Installments)
                .NotEmpty()
                .WithMessage("Installments field is required")
                .GreaterThan(0)
                .WithMessage("Installments field is invalid");
        }
    }
}
