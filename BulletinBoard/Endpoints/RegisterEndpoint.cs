﻿using BulletinBoard.Common.Entity;
using Microsoft.AspNetCore.Identity;

namespace BulletinBoard.Endpoints
{
    public class RegisterEndpoint
    {
        public static async Task<IResult> Handler(RegisterForm form, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            if(form.Password != form.ConfirmPassword)
            {
                return Results.BadRequest();
            }

            var user = new ApplicationUser() { UserName = form.Username };
            var userCreateResult = await userManager.CreateAsync(user, form.Password);

            if (!userCreateResult.Succeeded)
            {
                return Results.BadRequest();
            }

            await signInManager.SignInAsync(user, true);
            
            return Results.Ok();
        }
    }
}
