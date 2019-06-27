using MeiFacil.Payment.Domain.Core.Notifications;
using MeiFacil.Payment.Domain.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain.Services.PaymentService
{
    public class CalculateTax
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IDomainNotificationHandler> _notifications;

        public CalculateTax()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _notifications = new Mock<IDomainNotificationHandler>();
        }

        [Fact]
        public async Task CalculateTaxTestAsync()
        {
            var paymentService = new MeiFacil.Payment.Domain.Services.PaymentService(_unitOfWork.Object,
                                                   _notifications.Object);

            var netValue1 = paymentService.CalculateTax(250, 1);
            var netValue2 = paymentService.CalculateTax(250, 2);
            var netValue3 = paymentService.CalculateTax(250, 3);
            var netValue4 = paymentService.CalculateTax(250, 4);

            Assert.Equal(259.475M, netValue1);
            Assert.Equal(264.45M, netValue2);
            Assert.Equal(269.425M, netValue3);
            Assert.Equal(269.425M, netValue4);
        }
    }
}
