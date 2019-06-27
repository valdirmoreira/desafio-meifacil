using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeiFacil.Payment.Application.Interfaces;
using MeiFacil.Payment.Application.ViewModels;
using MeiFacil.Payment.Application.ViewModels.CheckingAccount;
using MeiFacil.Payment.Domain.Entities;
using MeiFacil.Payment.Domain.Interfaces;
using MeiFacil.Payment.Domain.Specifications;

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

        public async Task<CheckingAccountIndexViewModel> GetAllAsync(int pageIndex, int itemsPage, int? number)
        {
            var filterSpecification = new CheckingAccountFilterSpecification(number);
            var filterPaginatedSpecification =
                new CheckingAccountFilterPaginatedSpecification(itemsPage * pageIndex, itemsPage, number);

            var itemsOnPage = await _checkingAccountService.ListAsync(filterPaginatedSpecification);
            var totalItems = await _checkingAccountService.CountAsync(filterSpecification);

            var vm = new CheckingAccountIndexViewModel()
            {
                CheckingAccounts = itemsOnPage.Select(i => new CheckingAccountViewModel()
                {
                    Id = i.Id,
                    Balance = i.Balance,
                    Number = i.Number
                    
                }),
                NumberFilterApplied = number ?? 0,
                PaginationInfo = new PaginationInfoViewModel()
                {
                    ActualPage = pageIndex,
                    ItemsPerPage = itemsOnPage.Count,
                    TotalItems = totalItems,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / itemsPage)).ToString())
                }
            };

            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

            return vm;
        }
    }
}
