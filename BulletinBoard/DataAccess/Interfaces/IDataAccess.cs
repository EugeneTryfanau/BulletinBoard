using BulletinBoard.DAL.Repositories.Interfaces;

namespace BulletinBoard.DAL.DataAccess.Interfaces
{
    public interface IDataAccess
    {
        IProductCategoryRepository ProductCategoryRepository { get; set; }

        IProductRepository ProductRepository { get; set; }
    }
}
