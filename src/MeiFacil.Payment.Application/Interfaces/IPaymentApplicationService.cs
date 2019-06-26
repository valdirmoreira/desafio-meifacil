using MeiFacil.Payment.Application.ViewModels.Payment;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Application.Interfaces
{
    public interface IPaymentApplicationService
    {
        Task AddAsync(PaymentViewModel model);
    }
}
