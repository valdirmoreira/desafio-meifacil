using System.Collections.Generic;

namespace MeiFacil.Payment.Application.ViewModels.CheckingAccount
{
    public class CheckingAccountIndexViewModel
    {
        public IEnumerable<CheckingAccountViewModel> CheckingAccounts { get; set; }
        public int? NumberFilterApplied { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
