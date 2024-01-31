using ProvaPub.Models;
using ProvaPub.Models.Features.Orders;
using ProvaPub.Services.Features.Orders;

namespace ProvaPub.Services
{
    /// <summary> Serviço responsável por processar pagamentos de pedidos. </summary>
    public class OrderService : IOrderService
    {
        private readonly IDictionary<PaymentMethod, IPaymentMethod> _paymentMethods;

        /// <summary> Construtor da classe OrderService. </summary>
        /// <param name="paymentMethods">Dicionário que mapeia os métodos de pagamento aos objetos de pagamento correspondentes.</param>
        public OrderService(IDictionary<PaymentMethod, IPaymentMethod> paymentMethods)
        {
            _paymentMethods = paymentMethods;
        }

        /// <summary> Método para efetuar o pagamento de um pedido. </summary>
        /// <param name="paymentMethod">O método de pagamento escolhido.</param>
        /// <param name="paymentValue">O valor do pagamento.</param>
        /// <param name="customerId">O ID do cliente.</param>
        /// <returns>O pedido com o pagamento efetuado.</returns>
        public async Task<Order> PayOrder(PaymentMethod paymentMethod, decimal paymentValue, int customerId)
        {
            if (!_paymentMethods.ContainsKey(paymentMethod))
            {
                throw new ArgumentException("Método de pagamento inválido.");
            }

            var paymentInstance = _paymentMethods[paymentMethod];
            await paymentInstance.Pay(paymentValue);

            return new Order
            {
                CustomerId = customerId,
                Value = paymentValue,
                OrderDate = DateTime.UtcNow,
            };
        }
    }

}
