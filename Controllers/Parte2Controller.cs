using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
    /// <summary>
    /// Precisamos fazer algumas alterações:
    /// 1 - Não importa qual page é informada, sempre são retornados os mesmos resultados. Faça a correção.
    /// R: Feita a correção do código e tratativa de erro caso não venha uma numeração da página; 
    /// também foi adicionada o status code caso a requisição tenha sido feito correta, ou tenha caido na exceção
    /// 
    /// 2 - Altere os códigos abaixo para evitar o uso de "new", como em "new ProductService()". Utilize a Injeção de Dependência para resolver esse problema
    /// R: Feita a injeção de dependencia no controller e nos serviços para solucionar o problema.
    /// 
    /// 3 - Dê uma olhada nos arquivos /Models/CustomerList e /Models/ProductList. Veja que há uma estrutura que se repete. 
    /// Como você faria pra criar uma estrutura melhor, com menos repetição de código? E quanto ao CustomerService/ProductService. Você acha que seria possível evitar a repetição de código?
    /// R: Criado um serviço genérico para retornar o resultado da busca paginada e assim eliminar a duplicação de código podendo ser utilizada por outras entidades futuras
    /// 
    /// PS: Adicionei Documentação nos métodos para facilitar o entendimento
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class Parte2Controller : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;

        public Parte2Controller(IProductService productService, ICustomerService customerService)
        {
            _productService = productService;
            _customerService = customerService;
        }

        /// <summary> Lista os produtos com base no número da página. </summary>
        /// <param name="page">O número da página.</param>
        /// <returns>Uma ação HTTP que produzirá um objeto JSON contendo a lista de produtos ou uma resposta de erro 400 se o número da página for menor ou igual a zero.</returns>
        [HttpGet("products")]
        public ActionResult<ProductList> ListProducts(int page)
        {
            try
            {
                if (page <= 0)
                {
                    throw new InvalidPageNumberException();
                }

                var productList = _productService.ListProducts(page);
                return Ok(productList);
            }
            catch (InvalidPageNumberException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary> Lista os clientes com base no número da página. </summary>
        /// <param name="page">O número da página.</param>
        /// <returns>Uma ação HTTP que produzirá um objeto JSON contendo a lista de clientes ou uma resposta de erro 400 se o número da página for menor ou igual a zero.</returns>
        [HttpGet("customers")]
        public ActionResult<CustomerList> ListCustomers(int page)
        {
            try
            {
                if (page <= 0)
                {
                    throw new InvalidPageNumberException();
                }
                var customerList = _customerService.ListCustomers(page);
                return Ok(customerList);
            }
            catch (InvalidPageNumberException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

