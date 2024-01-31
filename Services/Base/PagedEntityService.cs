using Microsoft.EntityFrameworkCore;
using ProvaPub.Repository;

namespace ProvaPub.Services.Base
{
    /// <summary>
    /// Serviço genérico para operações com entidades paginadas.
    /// </summary>
    /// <typeparam name="T">O tipo da entidade.</typeparam>
    public class PagedEntityService<T> : IEntityService<T>
    {
        protected readonly TestDbContext _context;

        public PagedEntityService(TestDbContext context)
        {
            _context = context;
        }

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtém os resultados paginados de uma consulta.
        /// </summary>
        /// <param name="query">A consulta para obter os resultados.</param>
        /// <param name="page">O número da página.</param>
        /// <returns>Os resultados paginados.</returns>
        protected async Task<List<T>> GetPagedResultsAsync(IQueryable<T> query, int page)
        {
            if (page <= 0)
            {
                throw new ArgumentException("O número da página deve ser maior que zero.");
            }
            const int pageSize = 10;
            return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
