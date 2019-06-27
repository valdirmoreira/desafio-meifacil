using System.Threading.Tasks;

namespace MeiFacil.Payment.Domain.Interfaces
{
    public interface IPaymentService
    {
        Task<Entities.Payment> AddAsync(Entities.Payment entity);
        Task<Entities.Payment> CreateAsync(decimal value, int installments, int debitAccountNumber, int creditAccountNumber);
    }
}
