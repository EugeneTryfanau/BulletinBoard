using BulletinBoard.Common.Entity;
using BulletinBoard.Common.Patterns;
using BulletinBoard.DAL.Repositories.Interfaces;

namespace BulletinBoard.DAL.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        public Task<ProductCategory> CreateAsync(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory> GetItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
