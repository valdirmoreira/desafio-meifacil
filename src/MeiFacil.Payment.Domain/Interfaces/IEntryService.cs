using MeiFacil.Payment.Domain.Entities;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Domain.Interfaces
{
    public interface IEntryService
    {
        Task AddAsync(Entry entity);
    }
}
