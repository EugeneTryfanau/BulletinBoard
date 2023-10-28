using BulletinBoard;
using BulletinBoard.DAL.Data;
using BulletinBoard.DAL.Entity;
using BulletinBoard.Endpoints;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("BulletinBoard.DAL")));

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
        }
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
{
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/login";
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy => { policy.RequireRole("admin"); });
    options.AddPolicy("user", policy => { policy.RequireRole("user", "admin"); });
});

var app = builder.BuildWithSPA();

var apiEndpoints = app.MapGroup("/api");

//user
//TODO change pathes to unificate them
apiEndpoints.MapGet("/users", UserEndpoints.Handler);
apiEndpoints.MapGet("/users/{userId}", UserEndpoints.GetUserDetails).RequireAuthorization();
apiEndpoints.MapGet("/users/products/{userId}", ProductEndpoints.GetUsersProducts).RequireAuthorization();
apiEndpoints.MapPut("/users/change-password", UserEndpoints.ChangePassword).RequireAuthorization();
apiEndpoints.MapDelete("/users/{userId}", UserEndpoints.DeleteAccount).RequireAuthorization();

//auth
apiEndpoints.MapPost("/login", LoginEndpoint.Handler);
apiEndpoints.MapPost("/register", RegisterEndpoint.Handler);
apiEndpoints.MapGet("/logout", LogoutEndpoint.Handler).RequireAuthorization();

//admin
apiEndpoints.MapGet("/admin/users", UserEndpoints.GetUsers).RequireAuthorization("admin");
apiEndpoints.MapPost("/admin/users/{userId}", UserEndpoints.UserPromotion).RequireAuthorization("admin");

//categories
apiEndpoints.MapGet("/categories", CategoryEndpoints.CategoryList);

//products
apiEndpoints.MapGet("/products/{productId}", ProductEndpoints.GetProductById);
apiEndpoints.MapGet("/products/last/{userId}", ProductEndpoints.GetLastCreatedProductByUserId).RequireAuthorization();
apiEndpoints.MapPost("/products", ProductEndpoints.CreateProduct).RequireAuthorization();
apiEndpoints.MapDelete("/products/{productId}", ProductEndpoints.DeleteProductById).RequireAuthorization();

//products filter
apiEndpoints.MapGet("/products/pages/{category}/{pagesize}", ProductEndpoints.GetProductsPageCount);
apiEndpoints.MapGet("/products/pages/{category}/{pagesize}/{page}", ProductEndpoints.GetProductsPage);

//pictures
apiEndpoints.MapPost("/pictures/{productId}", PictureEndpoints.UploadPicture).RequireAuthorization();

app.Run();
