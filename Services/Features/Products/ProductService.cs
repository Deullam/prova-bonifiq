using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.Base;

namespace ProvaPub.Services
{
    public class ProductService : PagedEntityService<Product>, IProductService
    {
        public ProductService(TestDbContext context) : base(context) { }

        // <summary>
        /// Lista os produtos paginados.
        /// </summary>
        /// <param name="page">O número da página.</param>
        /// <returns>Uma lista paginada de produtos.</returns>
        public ProductList ListProducts(int page)
        {
            var query = _context.Products.AsQueryable();
            var products = GetPagedResultsAsync(query, page).Result;

            return new ProductList { Products = products, HasNext = true, TotalCount = 100 };
        }
    }
}
