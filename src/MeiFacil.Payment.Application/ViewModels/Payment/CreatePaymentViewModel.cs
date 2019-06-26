namespace MeiFacil.Payment.Application.ViewModels.Payment
{
    public class CreatePaymentViewModel
    {
        public decimal Value { get; set; }
        public int Installments { get; set; }
        public int DebitAccountNumber { get; set; }
        public int CreditAccountNumber { get; set; }
    }
}
