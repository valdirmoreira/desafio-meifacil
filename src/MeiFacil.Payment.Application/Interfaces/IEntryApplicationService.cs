using MeiFacil.Payment.Application.ViewModels.Entry;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Application.Interfaces
{
    public interface IEntryApplicationService
    {
        Task AddAsync(EntryViewModel model);
    }
}
