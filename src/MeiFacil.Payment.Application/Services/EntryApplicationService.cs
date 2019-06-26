using System.Threading.Tasks;
using AutoMapper;
using MeiFacil.Payment.Application.Interfaces;
using MeiFacil.Payment.Application.ViewModels.Entry;
using MeiFacil.Payment.Domain.Entities;
using MeiFacil.Payment.Domain.Interfaces;

namespace MeiFacil.Payment.Application.Services
{
    public class EntryApplicationService : IEntryApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IEntryService _entryService;

        public EntryApplicationService(
            IMapper mapper,
            IEntryService entryService)
        {
            _entryService = entryService;
            _mapper = mapper;
        }

        public async Task AddAsync(EntryViewModel model)
        {
            await _entryService.AddAsync(_mapper.Map<Entry>(model));
        }
    }
}
