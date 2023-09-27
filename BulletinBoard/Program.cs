using BulletinBoard;
using BulletinBoard.Common.Entity;
using BulletinBoard.Endpoints;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("cookie").AddCookie("cookie");
builder.Services.AddAuthorization();

var app = builder.BuildWithSPA();

var apiEndpoints = app.MapGroup("/api");


apiEndpoints.MapGet("/user", UserEndpoint.Handler);
apiEndpoints.MapPost("/login", LoginEndpoint.Handler);
//TODO ned to do registrationEndpoint
apiEndpoints.MapPost("/register", () => "Hello World");
apiEndpoints.MapGet("/logout", LogoutEndpoint.Handler).RequireAuthorization();

app.Run();
