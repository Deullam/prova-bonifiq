namespace ProvaPub.Models.Features.Orders
{
    public class PixPayment : IPaymentMethod
    {
        /// <summary>
        /// Método para efetuar o pagamento via Pix.
        /// </summary>
        /// <param name="paymentValue">O valor do pagamento.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public async Task Pay(decimal paymentValue)
        {
            // Lógica específica para pagamento via Pix
        }
    }
}
