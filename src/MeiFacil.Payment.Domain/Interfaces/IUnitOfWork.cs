using System;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
