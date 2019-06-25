using MeiFacil.Payment.Domain.Entities;
using MeiFacil.Payment.Domain.Interfaces;
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
    }
}
