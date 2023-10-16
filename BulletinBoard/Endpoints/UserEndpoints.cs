using BulletinBoard.DAL.Data;
using BulletinBoard.DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace BulletinBoard.Endpoints
{
    public class UserEndpoints
    {
        public static Dictionary<string, string> Handler(ClaimsPrincipal user) =>
            user.Claims.ToDictionary(x => x.Type, x => x.Value);

        public static async Task<IList<ApplicationUser>> GetUsers(SignInManager<ApplicationUser> signInManager)
        {
            var users = await signInManager.UserManager.GetUsersInRoleAsync("user");

            return users;
        }

        public static async Task<IResult> UserPromotion(SignInManager<ApplicationUser> signInManager, string userId)
        {
            var user = await signInManager.UserManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            
            if(user == null)
            {
                return Results.BadRequest();
            }

            await signInManager.UserManager.RemoveFromRolesAsync(user, new List<string>() { "user", "user" });
            await signInManager.UserManager.AddToRoleAsync(user, "admin");
            
            return Results.BadRequest();
        }

        public static async Task<ApplicationUser?> GetUserInfo(ApplicationDbContext db, string userId)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if(user != null) return user;

            return null;
        }
    }
}
