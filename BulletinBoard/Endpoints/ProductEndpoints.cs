using BulletinBoard.DAL.Data;
using BulletinBoard.DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BulletinBoard.Endpoints
{
    public class ProductEndpoints
    {
        public static async Task<List<Product>> GetProductsPage(ApplicationDbContext db, int page = 1, int category = 0, int pagesize = 8, string searchString = "%")
        {
            searchString = searchString != "u00" ? $"%" + searchString + $"%" : "%";

            if (category == 0)
            {
                var result = await db.Products.Include(x => x.Pictures).Where(x => EF.Functions.Like(x.Name, searchString))
                    .OrderByDescending(x => x.Id).Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
                return result;
            }
            else
            {
                var result = await db.Products.Include(x => x.Pictures).Where<Product>(x => x.CategoryId == category).Where(x => EF.Functions.Like(x.Name, searchString))
                                .OrderByDescending(x => x.Id).Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
                return result;
            }
        }

        public static async Task<int> GetProductsPageCount(ApplicationDbContext db, int category = 0, int pagesize = 8, string searchString = "%")
        {
            searchString = searchString.Length > 0 ? $"%" + searchString + $"%" : "%";

            if (category == 0)
            {
                var products = await db.Products.Where(x => EF.Functions.Like(x.Name, searchString)).CountAsync();
                if (products < pagesize) return 1;

                if (products % pagesize == 0)
                {
                    products /= pagesize;
                }
                else
                {
                    products = products / pagesize + 1;
                }

                return products;
            }
            else
            {
                var products = await db.Products.Where(x => EF.Functions.Like(x.Name, searchString)).Where<Product>(x => x.CategoryId == category).CountAsync();
                if (products < pagesize) return 1;

                if (products % pagesize == 0)
                {
                    products /= pagesize;
                }
                else
                {
                    products = products / pagesize + 1;
                }

                return products;
            }
        }

        public static async Task<Product?> GetProductById(ApplicationDbContext db, int productId)
        {
            var product = await db.Products.Include(x => x.Pictures).Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);

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
            var usersProducts = await db.Products.Include(x => x.Pictures)
                .Where(x => x.UserId == userId).OrderByDescending(x => x.Id).ToListAsync();
            return usersProducts;
        }

        public static async Task<IResult> ChangeProductInfo(ApplicationDbContext db, ProductInfo productInfo)
        {
            if (productInfo == null || productInfo.Id == 0)
            {
                return Results.BadRequest(new { message = "Нет информации об объявлении." });
            }

            var productToChange = await db.Products.FirstOrDefaultAsync(x => x.Id == productInfo.Id);
            var category = await db.Categories.FirstOrDefaultAsync(x => x.Id == productInfo.CategoryId); 
            if (productToChange != null && category != null)
            {
                productToChange.Name = productInfo.Name != null && productInfo.Name != "" ? productInfo.Name : productToChange.Name;
                productToChange.Price = productInfo.Price > 0 ? productInfo.Price : productToChange.Price;
                productToChange.Category = productInfo.CategoryId != category.Id ? category : productToChange.Category;
                productToChange.Description = productInfo.Description != null && productInfo.Description != "" ? productInfo.Description : productToChange.Description;
                productToChange.ConditionIsNew = productInfo.ConditionIsNew;

                await db.SaveChangesAsync();

                return Results.Ok();
            }
            return Results.BadRequest(new { message = "Нет информации об объявлении или категории товара." });
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
