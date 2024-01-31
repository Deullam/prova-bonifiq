namespace ProvaPub.Services
{
    public interface IEntityService<T>
    {
        Task<List<T>> GetAll();
    }
}
