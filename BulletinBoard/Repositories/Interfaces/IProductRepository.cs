using BulletinBoard.Common.Entity;
using BulletinBoard.Common.Patterns;

namespace BulletinBoard.DAL.Repositories.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId);
    }
}
