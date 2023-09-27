using BulletinBoard.Common.Entity;
using Microsoft.AspNetCore.Identity;

namespace BulletinBoard.Endpoints
{
    public class LoginEndpoint
    {
        public static async Task<IResult> Handler(LoginForm form, SignInManager<ApplicationUser> signInManager)
        {
            var result = await signInManager.PasswordSignInAsync(form.Username, form.Password, true, false);

            if (result.Succeeded)
            {
                return Results.Ok();
            }

            return Results.BadRequest();
        }
    }
}
