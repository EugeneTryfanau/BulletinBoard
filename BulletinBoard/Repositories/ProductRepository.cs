using BulletinBoard.Common.Entity;
using BulletinBoard.DAL.Repositories.Interfaces;

namespace BulletinBoard.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> CreateAsync(Product item)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
