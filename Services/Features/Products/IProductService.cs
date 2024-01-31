using ProvaPub.Models;

namespace ProvaPub.Services
{
    public interface IProductService : IEntityService<Product>
    {
        ProductList ListProducts(int page);
    }
}
