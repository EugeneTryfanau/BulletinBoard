using BulletinBoard.Common.Entity;
using BulletinBoard.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BulletinBoard.Endpoints
{
    public class UserEndpoint
    {
        public static Dictionary<string, string> Handler(ClaimsPrincipal user) =>
            user.Claims.ToDictionary(x => x.Type, x => x.Value);

        public static async Task<List<ApplicationUser>> GetUsers(ClaimsPrincipal user, ApplicationDbContext db)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            return await db.Users
                .ToListAsync();
        }
    }
}
