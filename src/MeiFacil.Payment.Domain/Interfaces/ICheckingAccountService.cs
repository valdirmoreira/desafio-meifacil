using MeiFacil.Payment.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Domain.Interfaces
{
    public interface ICheckingAccountService
    {
        Task AddAsync(CheckingAccount entity);
        Task<CheckingAccount> GetByNumberAsync(int number);

        Task<IReadOnlyList<CheckingAccount>> ListAsync(ISpecification<CheckingAccount> spec);

        Task<int> CountAsync(ISpecification<CheckingAccount> spec);
    }
}
