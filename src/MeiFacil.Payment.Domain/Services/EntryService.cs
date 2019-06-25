using MeiFacil.Payment.Domain.Entities;
using MeiFacil.Payment.Domain.Interfaces;
using System.Threading.Tasks;

namespace MeiFacil.Payment.Domain.Services
{
    public class EntryService : IEntryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Entry entity)
        {
            _unitOfWork.EntryRepository.Add(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
