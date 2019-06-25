using MeiFacil.Payment.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICheckingAccountRepository CheckingAccountRepository { get; }
        IEntryRepository EntryRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        Task<bool> CommitAsync();
    }
}
