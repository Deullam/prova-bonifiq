using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.Base;

namespace ProvaPub.Services
{
    public class CustomerService : PagedEntityService<Customer>, ICustomerService
    {
        TestDbContext _ctx;
        public CustomerService(TestDbContext context) : base(context) { }

        /// <summary>
        /// Lista os clientes paginados.
        /// </summary>
        /// <param name="page">O número da página.</param>
        /// <returns>Uma lista paginada de clientes.</returns>
        public CustomerList ListCustomers(int page)
        {
            var query = _context.Customers.AsQueryable();
            var customers = GetPagedResultsAsync(query, page).Result;

            return new CustomerList { Customers = customers, HasNext = true, TotalCount = 100 };
        }

        /// <summary>
        /// Verifica se um cliente pode fazer uma compra.
        /// </summary>
        /// <param name="customerId">O ID do cliente.</param>
        /// <param name="purchaseValue">O valor da compra.</param>
        /// <returns>True se o cliente pode fazer a compra, caso contrário, false.</returns>
        public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
        {
            if (customerId <= 0) throw new ArgumentOutOfRangeException(nameof(customerId));

            if (purchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(purchaseValue));

            //Business Rule: Non registered Customers cannot purchase
            var customer = await _ctx.Customers.FindAsync(customerId);
            if (customer == null) throw new InvalidOperationException($"Customer Id {customerId} does not exists");

            //Business Rule: A customer can purchase only a single time per month
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            var ordersInThisMonth = await _ctx.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
            if (ordersInThisMonth > 0)
                return false;

            //Business Rule: A customer that never bought before can make a first purchase of maximum 100,00
            var haveBoughtBefore = await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
            if (haveBoughtBefore == 0 && purchaseValue > 100)
                return false;

            return true;
        }

        public Task<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
