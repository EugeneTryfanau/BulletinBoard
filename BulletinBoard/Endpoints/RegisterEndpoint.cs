using BulletinBoard.DAL.Entity;
using Microsoft.AspNetCore.Identity;

namespace BulletinBoard.Endpoints
{
    public class RegisterEndpoint
    {
        public static async Task<IResult> Handler(RegisterForm form, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            if (form.Password != form.ConfirmPassword)
            {
                return Results.BadRequest();
            }

            var user = new ApplicationUser()
            {
                UserName = form.Username,
                Email = form.Email,
                City = form.City != null ? form.City : null,
                PhoneNumber = form.PhoneNumber != null ? form.PhoneNumber : null,
                Gender = form.Gender != null ? form.Gender : null,
                BirthDate = form.BirthdayDate != null ? Convert.ToDateTime(form.BirthdayDate) : DateTime.Now
            };
            var userCreateResult = await userManager.CreateAsync(user, form.Password);
            await userManager.AddToRoleAsync(user, "user");

            if (!userCreateResult.Succeeded)
            {
                return Results.BadRequest();
            }

            await signInManager.SignInAsync(user, true);

            return Results.Ok();
        }
    }
}
