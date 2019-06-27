using MeiFacil.Payment.Domain.Entities;
using MeiFacil.Payment.Domain.Interfaces;
using MeiFacil.Payment.Domain.Specifications;
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

        public async Task<CheckingAccount> GetByNumberAsync(int number)
        {
            return (await _unitOfWork
                .CheckingAccountRepository
                .ListAsync(new CheckingAccountFilterSpecification(number)))
                .FirstOrDefault();
        }
    }
}
