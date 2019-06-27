using MeiFacil.Payment.Application.ViewModels.Payment;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Application.Interfaces
{
    public interface IPaymentApplicationService
    {
        Task<CreatedPaymentViewModel> AddAsync(CreatePaymentViewModel model);
    }
}
