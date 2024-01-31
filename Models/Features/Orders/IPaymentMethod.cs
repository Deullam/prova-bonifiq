namespace ProvaPub.Models.Features.Orders
{
    /// <summary>
    /// Interface que define o contrato para os diferentes métodos de pagamento.
    /// </summary>
    public interface IPaymentMethod
    {
        /// <summary>
        /// Método para efetuar o pagamento.
        /// </summary>
        Task Pay(decimal paymentValue);
    }
}
