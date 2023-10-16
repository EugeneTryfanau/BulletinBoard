﻿using BulletinBoard.DAL.Data;
using BulletinBoard.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Endpoints
{
    public class ProductEndpoints
    {
        public static async Task<List<Product>> GetProductsPage(ApplicationDbContext db, int page = 1, int pagesize = 2)
        {
            var result = await db.Products.OrderByDescending(x => x.Id).Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return result;
        }

        public static async Task<int> GetProductsPageCount(ApplicationDbContext db)
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

        public static async Task<Product?> GetProductById(ApplicationDbContext db, int productId)
        {
            var product = await db.Products.SingleOrDefaultAsync(x => x.Id == productId);

            return product;
        }

        public static async Task<IResult> CreateProduct(CreateProductForm productForm, ApplicationDbContext db)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Id == productForm.UserId);
            var category = await db.Categories.FirstOrDefaultAsync(x => x.Id == productForm.ProductCategoryId);


            if (user != null && category != null)
            {
                user.Products.Add(
                        new Product()
                        {
                            Name = productForm.ProductName,
                            Description = productForm.ProductDescription,
                            Category = category,
                            User = user,
                            UserId = user.Id,
                            Price = productForm.ProductPrice,
                            ConditionIsNew = productForm.ConditionIsNew
                        });
                db.SaveChanges();

                return Results.Ok();
            }

            return Results.BadRequest();
        }
    }
}