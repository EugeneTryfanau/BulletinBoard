using BulletinBoard.DAL.Entity;
using Microsoft.AspNetCore.Identity;

namespace BulletinBoard.Endpoints
{
    public class LogoutEndpoint
    {
        public static async Task<IResult> Handler(SignInManager<ApplicationUser> signInManager)
        {
            await signInManager.SignOutAsync();
            return Results.Ok();
        }
    }
}
