using MeiFacil.Payment.Domain.Entities;
using MeiFacil.Payment.Domain.Interfaces;
using MeiFacil.Payment.Domain.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Domain.Services
{
    public class CheckingAccountService : ICheckingAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckingAccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(CheckingAccount entity)
        {
            _unitOfWork.CheckingAccountRepository.Add(entity);
            await _unitOfWork.CommitAsync();
        }

        public Task<int> CountAsync(ISpecification<CheckingAccount> spec)
        {
            return _unitOfWork.CheckingAccountRepository.CountAsync(spec);
        }

        public async Task<CheckingAccount> GetByNumberAsync(int number)
        {
            return (await _unitOfWork
                .CheckingAccountRepository
                .ListAsync(new CheckingAccountFilterSpecification(number)))
                .FirstOrDefault();
        }

        public Task<IReadOnlyList<CheckingAccount>> ListAsync(ISpecification<CheckingAccount> spec)
        {
            return _unitOfWork.CheckingAccountRepository.ListAsync(spec);
        }
    }
}
