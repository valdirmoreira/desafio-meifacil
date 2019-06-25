using MeiFacil.Payment.Domain.Entities;
using MeiFacil.Payment.Domain.Interfaces;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Domain.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Entities.Payment entity)
        {
            _unitOfWork.PaymentRepository.Add(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
