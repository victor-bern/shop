using Backend.Domain.Entities;

namespace Backend.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task SaveAsync(Product product);
        Task UpdateAsync(int id, Product product);
        Task DeleteAsync(int id);
    }
}
