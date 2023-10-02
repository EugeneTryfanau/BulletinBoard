using BulletinBoard.Common.Entity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BulletinBoard
{
    public static class BuildExtention
    {
        public static WebApplication BuildWithSPA(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(_ => { });

            app.Use((ctx, next) =>
            {
                if (ctx.Request.Path.StartsWithSegments("/api"))
                {
                    ctx.Response.StatusCode = 404;
                    return Task.CompletedTask;
                }

                return next();
            });

            app.UseSpa(x => { x.UseProxyToSpaDevelopmentServer("http://localhost:4200"); });

            using var scope = app.Services.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            ApplicationUser? admin = null;

            if (!userManager.Users.Any(x => x.UserName == "admin"))
            {
                admin = new ApplicationUser { UserName = "admin" };

                userManager.CreateAsync(admin, "password").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(admin, "admin").GetAwaiter().GetResult();
            }

            return app;
        }
    }
}
