namespace ProvaPub.Models.Features.Orders
{
    /// <summary>
    /// Classe responsável por processar pagamentos via PayPal.
    /// </summary>
    public class PayPalPayment : IPaymentMethod
    {
        /// <summary>
        /// Método para efetuar o pagamento via PayPal.
        /// </summary>
        /// <param name="paymentValue">O valor do pagamento.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public async Task Pay(decimal paymentValue)
        {
            // Lógica específica para pagamento via PayPal
        }
    }
}
