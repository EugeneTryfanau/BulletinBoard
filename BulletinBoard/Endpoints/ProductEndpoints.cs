using BulletinBoard.DAL.Data;
using BulletinBoard.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace BulletinBoard.Endpoints
{
    public class ProductEndpoints
    {
        public static async Task<List<Product>> GetProductsPage(ApplicationDbContext db, int page = 1, int category = 0, int pagesize = 2)
        {
            if (category == 0)
            {
                var result = await db.Products.Include(x => x.Pictures)
                    .OrderByDescending(x => x.Id).Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
                return result;
            }
            else
            {
                var result = await db.Products.Where<Product>(x => x.CategoryId == category)
                                .OrderByDescending(x => x.Id).Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
                return result;
            }

        }

        public static async Task<int> GetProductsPageCount(ApplicationDbContext db, int category = 0)
        {
            if (category == 0)
            {
                var products = await db.Products.CountAsync();
                if (products < 2) return 1;

                if (products % 2 == 0)
                {
                    products /= 2;
                }
                else
                {
                    products = products / 2 + 1;
                }

                return products;
            }
            else
            {
                var products = await db.Products.Where<Product>(x => x.CategoryId == category).CountAsync();
                if (products < 2) return 1;

                if (products % 2 == 0)
                {
                    products /= 2;
                }
                else
                {
                    products = products / 2 + 1;
                }

                return products;
            }
        }

        public static async Task<Product?> GetProductById(ApplicationDbContext db, int productId)
        {
            var product = await db.Products.SingleOrDefaultAsync(x => x.Id == productId);

            return product;
        }

        public static async Task<int> GetLastCreatedProductByUserId(ApplicationDbContext db, string userId)
        {
            var product = await db.Products.Where(x => x.UserId == userId).MaxAsync(s => s.Id);

            return product;
        }

        public static async Task<IResult> CreateProduct(CreateProductForm productForm, ApplicationDbContext db)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Id == productForm.UserId);
            var category = await db.Categories.FirstOrDefaultAsync(x => x.Id == productForm.ProductCategoryId);


            if (user != null && category != null)
            {
                var product = new Product()
                {
                    Name = productForm.ProductName,
                    Description = productForm.ProductDescription,
                    Category = category,
                    User = user,
                    UserId = user.Id,
                    Price = productForm.ProductPrice,
                    ConditionIsNew = productForm.ConditionIsNew
                };

                user.Products.Add(product);
                await db.SaveChangesAsync();

                return Results.Ok();
            }
            return Results.BadRequest();
        }

        public static async Task<List<Product>> GetUsersProducts(ApplicationDbContext db, string userId)
        {
            var usersProducts = await db.Products.Where(x => x.UserId == userId).ToListAsync();
            return usersProducts;
        }

        public static async Task<IResult> DeleteProductById(ApplicationDbContext db, int productId)
        {
            var product = await db.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product == null)
            {
                return Results.BadRequest("Wrong productId");
            }
            _ = db.Products.Remove(product);
            db.SaveChanges();

            return Results.Ok();
        }
    }
}
