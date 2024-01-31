using ProvaPub.Models.Features.Orders;
using ProvaPub.Models;

namespace ProvaPub.Services.Features.Orders
{
    /// <summary>
    /// Interface para o serviço responsável por processar pedidos.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Método para efetuar o pagamento de um pedido.
        /// </summary>
        /// <param name="paymentMethod">O método de pagamento escolhido.</param>
        /// <param name="paymentValue">O valor do pagamento.</param>
        /// <param name="customerId">O ID do cliente.</param>
        /// <returns>O pedido com o pagamento efetuado.</returns>
        Task<Order> PayOrder(PaymentMethod paymentMethod, decimal paymentValue, int customerId);
    }
}

