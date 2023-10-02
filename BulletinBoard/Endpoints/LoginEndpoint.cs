using BulletinBoard.Common.Entity;
using BulletinBoard.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Security.Claims;

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
