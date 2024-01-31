using System.Threading.Tasks;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public interface ICustomerService : IEntityService<Customer>
    {
        CustomerList ListCustomers(int page);
        Task<bool> CanPurchase(int customerId, decimal purchaseValue);
    }
}
