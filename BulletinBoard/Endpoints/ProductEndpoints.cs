namespace BulletinBoard.Endpoints
{
    public class ProductEndpoints
    {
        //public static async Task<List<Product>> ListProducts(ClaimsPrincipal user, ApplicationDbContext db)
        //{
        //    var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        //    return await db.Products
        //        .Include(x => x.Category)
        //        .Where(x => x.User.Id == userId)
        //        .ToListAsync();
        //}

        //public static async Task<Product> GetProduct(string id, ClaimsPrincipal user, ApplicationDbContext db)
        //{
        //    var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        //    return await db.Products
        //        .Include(x => x.Category)
        //        .Where(x => x.User.Id == userId)
        //        .FirstOrDefaultAsync(x => x.Id.ToString() == id);
        //}

        //public static async Task<IResult> AddProduct(ClaimsPrincipal user, ApplicationDbContext db)
        //{
        //    var userDb = await db.Users.FirstOrDefaultAsync(x => x.Id == user.FindFirstValue(ClaimTypes.NameIdentifier));
        //    userDb.Products.Add(new Product() { User = userDb });
        //    await db.SaveChangesAsync();

        //    return Results.Ok();

        //}

    }
}
