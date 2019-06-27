using System;

namespace MeiFacil.Payment.Application.ViewModels.CheckingAccount
{
    public class CheckingAccountViewModel
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public decimal Balance { get; set; }
    }
}
