using MeiFacil.Payment.Application.ViewModels.CheckingAccount;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Application.Interfaces
{
    public interface ICheckingAccountApplicationService
    {
        Task AddAsync(CheckingAccountViewModel model);
        Task<CheckingAccountIndexViewModel> GetAllAsync(int pageIndex, int itemsPage, int? number);
    }
}
