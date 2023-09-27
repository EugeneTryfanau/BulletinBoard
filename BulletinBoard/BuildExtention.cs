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

            return app;
        }
    }
}
