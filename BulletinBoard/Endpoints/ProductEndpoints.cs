using BulletinBoard.DAL.Data;
using BulletinBoard.DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard.Endpoints
{
    public class ProductEndpoints
    {
        public static async Task<IResult> CreateProduct(SignInManager<ApplicationUser> signInManager, ApplicationDbContext db, string userId)
        {
            return Results.Ok();
        }

    }
}
