using BulletinBoard.DAL.Data;
using BulletinBoard.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BulletinBoard.Endpoints
{
    public class UserEndpoints
    {
        public static Dictionary<string, string> Handler(ClaimsPrincipal user) =>
            user.Claims.ToDictionary(x => x.Type, x => x.Value);

        public static async Task<List<ApplicationUser>> GetUsers(ClaimsPrincipal user, ApplicationDbContext db)
        {
            return await db.Users
                .ToListAsync();
        }
    }
}
