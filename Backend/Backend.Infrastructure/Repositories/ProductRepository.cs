using Backend.Domain.Entities;
using Backend.Domain.Exceptions;
using Backend.Infrastructure.DataContext;
using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (prod == null) throw new ProductException("Não existe produto com esse id");

            return prod;
        }

        public async Task SaveAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Product product)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (prod == null) throw new ProductException("Não existe produto com esse id");

            prod.ProductName = product.ProductName;
            prod.ProductCode = product.ProductCode;
            prod.Price = product.Price;
            prod.PromocionalPrice = product.PromocionalPrice;
            prod.Image = product.Image;

            _context.Update(prod);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (prod == null) throw new ProductException("Não existe produto com esse id");

            _context.Remove(prod);
            await _context.SaveChangesAsync();
        }
    }
}
