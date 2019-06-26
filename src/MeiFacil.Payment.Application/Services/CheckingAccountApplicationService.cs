using System.Threading.Tasks;
using AutoMapper;
using MeiFacil.Payment.Application.Interfaces;
using MeiFacil.Payment.Application.ViewModels.CheckingAccount;
using MeiFacil.Payment.Domain.Entities;
using MeiFacil.Payment.Domain.Interfaces;

namespace MeiFacil.Payment.Application.Services
{
    public class CheckingAccountApplicationService : ICheckingAccountApplicationService
    {
        private readonly IMapper _mapper;
        private readonly ICheckingAccountService _checkingAccountService;

        public CheckingAccountApplicationService(
            IMapper mapper,
            ICheckingAccountService checkingAccountService)
            
        {
            _checkingAccountService = checkingAccountService;
            _mapper = mapper;
        }

        public async Task AddAsync(CheckingAccountViewModel model)
        {
            await _checkingAccountService.AddAsync(_mapper.Map<CheckingAccount>(model));
        }
    }
}
