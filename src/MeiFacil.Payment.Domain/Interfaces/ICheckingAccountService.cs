using MeiFacil.Payment.Domain.Entities;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Domain.Interfaces
{
    public interface ICheckingAccountService
    {
        Task AddAsync(CheckingAccount entity);
        Task<CheckingAccount> GetByNumberAsync(int number);
    }
}
