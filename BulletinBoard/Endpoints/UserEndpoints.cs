using BulletinBoard.DAL.Data;
using BulletinBoard.DAL.Entity;
using Duende.IdentityServer.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public static async Task<ApplicationUser?> GetUserDetails(ApplicationDbContext db, string userId)
        {
            var userInfo = await db.Users.FirstOrDefaultAsync(x => x.Id == userId);

            return userInfo;
        }

        public static async Task<IResult> ChangeUserInfo(UserManager<ApplicationUser> userManager,  ApplicationUserInfo user)
        {
            if (user == null || user.Id == null)
            {
                return Results.BadRequest(new { message = "Нет информации о пользователе." });
            }

            var userToChange = await userManager.FindByIdAsync(user.Id);
            if (userToChange != null)
            {
                userToChange.UserName = user.UserName != null && user.UserName != "" && userToChange.UserName != "admin" ? user.UserName : userToChange.UserName;
                userToChange.City = user.City != null && user.City != "" ? user.City : userToChange.City;
                userToChange.Email = user.Email != null && user.Email != "" ? user.Email : userToChange.Email;
                userToChange.Gender = user.Gender != null && user.Gender != "" ? user.Gender : userToChange.Gender;
                userToChange.PhoneNumber = user.PhoneNumber != null && user.PhoneNumber != "" ? user.PhoneNumber : userToChange.PhoneNumber;
                userToChange.BirthDate = user.BirthDate != null && user.BirthDate != "" ? Convert.ToDateTime(user.BirthDate) : userToChange.BirthDate;

                var result = await userManager.UpdateAsync(userToChange);

                if (result.Succeeded)
                {
                    return Results.Ok(result.Succeeded);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        return Results.BadRequest(new { message = error.Description });
                    }
                }
            }
            return Results.BadRequest(new { message = "Нет информации о пользователе." });
        }

        public static async Task<IResult> ChangePassword(UserManager<ApplicationUser> userManager, ChangePasswordModel model)
        {
            if (model == null || model.NewPassword == null || model.NewPassword == "")
            {
                return Results.BadRequest(new { message = "Не введён пароль." });
            }

            var user = await userManager.FindByIdAsync(model.UserId);
            if (user != null)
            {
                var _passwordValidator =
                    userManager.PasswordValidators.FirstOrDefault();
                var _passwordHasher =
                    userManager.PasswordHasher;

                if (_passwordValidator == null)
                {
                    return Results.BadRequest("Validator error, check password validator");
                }

                IdentityResult result =
                    await _passwordValidator.ValidateAsync(userManager, user, model.NewPassword);
                if (result.Succeeded)
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                    await userManager.UpdateAsync(user);
                    return Results.Ok(result.Succeeded);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        return Results.BadRequest(new { message = error.Description });
                    }
                }
            }
            else
            {
                return Results.BadRequest(new { message = "Пользователь не найден." });
            }

            return Results.Ok(model);
        }

        public static async Task<IResult> UserPromotion(SignInManager<ApplicationUser> signInManager, string userId)
        {
            var user = await signInManager.UserManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return Results.BadRequest();
            }

            await signInManager.UserManager.RemoveFromRolesAsync(user, new List<string>() { "user", "user" });
            await signInManager.UserManager.AddToRoleAsync(user, "admin");

            return Results.BadRequest();
        }

        public static async Task<IResult> DeleteAccount(SignInManager<ApplicationUser> signInManager, string userId)
        {
            var user = await signInManager.UserManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                return Results.BadRequest("Wrong userId");
            }

            await signInManager.SignOutAsync();
            _ = await signInManager.UserManager.DeleteAsync(user);

            return Results.Ok();
        }
    }
}
