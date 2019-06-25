using System.Threading.Tasks;

namespace MeiFacil.Payment.Domain.Interfaces
{
    public interface IPaymentService
    {
        Task AddAsync(Entities.Payment entity);
    }
}
