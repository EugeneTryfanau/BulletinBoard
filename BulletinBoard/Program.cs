using BulletinBoard;
using BulletinBoard.Common.Entity;
using BulletinBoard.Data;
using BulletinBoard.Endpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireNonAlphanumeric = false;
        }
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization();

var app = builder.BuildWithSPA();

var apiEndpoints = app.MapGroup("/api");


apiEndpoints.MapGet("/user", UserEndpoint.Handler);
apiEndpoints.MapPost("/login", LoginEndpoint.Handler);
apiEndpoints.MapPost("/register", RegisterEndpoint.Handler);
apiEndpoints.MapGet("/logout", LogoutEndpoint.Handler).RequireAuthorization();

apiEndpoints.MapGet("/users", UserEndpoint.GetUsers).RequireAuthorization("admin");

////get list of products
//apiEndpoints.MapGet("/products", ProductEndpoints.ListProducts);
////get product
//apiEndpoints.MapGet("/products/{id:int}", ProductEndpoints.GetProduct);
////add picture (maybe it will work in update)
//apiEndpoints.MapPost("/products/add-product", ProductEndpoints.AddProduct).RequireAuthorization("user");
////change product
////apiEndpoints.MapPost("/products/{id:int}", () => { });

app.Run();
