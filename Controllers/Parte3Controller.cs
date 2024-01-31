using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models.Features.Orders;
using ProvaPub.Services.Features.Orders;

namespace ProvaPub.Controllers
{
	
	/// <summary> Esse teste simula um pagamento de uma compra.
	/// O método PayOrder aceita diversas formas de pagamento. Dentro desse método é feita uma estrutura de diversos "if" para cada um deles.
	/// Sabemos, no entanto, que esse formato não é adequado, em especial para futuras inclusões de formas de pagamento.
	/// Como você reestruturaria o método PayOrder para que ele ficasse mais aderente com as boas práticas de arquitetura de sistemas?
	/// </summary>
	
    /// <summary> Controlador responsável por gerenciar os pedidos na API. </summary>
    [ApiController]
    [Route("[controller]")]
    public class Parte3Controller : ControllerBase
    {
        private readonly IOrderService _orderService;

        /// <summary> Construtor da classe Parte3Controller.</summary>
        /// <param name="orderService">Serviço responsável por processar os pedidos.</param>
        public Parte3Controller(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary> Método para realizar um pedido de compra com um método de pagamento específico. </summary>
        /// <param name="paymentMethod">O método de pagamento escolhido.</param>
        /// <param name="paymentValue">O valor do pagamento.</param>
        /// <param name="customerId">O ID do cliente.</param>
        /// <returns>O pedido com o pagamento efetuado.</returns>
        [HttpGet("orders")]
        public async Task<IActionResult> PlaceOrder(PaymentMethod paymentMethod, decimal paymentValue, int customerId)
        {
            try
            {
                // Efetua o pagamento do pedido
                var order = await _orderService.PayOrder(paymentMethod, paymentValue, customerId);

                // Retorna o pedido com o pagamento efetuado
                return Ok(order);
            }
            catch (ArgumentException ex)
            {
                // Se ocorrer um erro de argumento inválido (por exemplo, método de pagamento inválido)
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Se ocorrer qualquer outro tipo de erro
                return StatusCode(500, $"An error occurred while processing the order: {ex.Message}");
            }
        }
    }

}
