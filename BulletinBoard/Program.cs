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


apiEndpoints.MapGet("/user", UserEndpoints.Handler);
apiEndpoints.MapPost("/login", LoginEndpoint.Handler);
apiEndpoints.MapPost("/register", RegisterEndpoint.Handler);
apiEndpoints.MapGet("/logout", LogoutEndpoint.Handler).RequireAuthorization();
apiEndpoints.MapGet("/user-profile/{userId}", UserEndpoints.GetUserDetails).RequireAuthorization();
apiEndpoints.MapPost("/user-profile/change-password", UserEndpoints.ChangePassword).RequireAuthorization();

apiEndpoints.MapGet("/categories", CategoryEndpoints.CategoryList);

apiEndpoints.MapGet("/users", UserEndpoints.GetUsers).RequireAuthorization("admin");
apiEndpoints.MapPost("/users/{userId}", UserEndpoints.UserPromotion).RequireAuthorization("admin");

apiEndpoints.MapGet("/products/pages/{category}", ProductEndpoints.GetProductsPageCount);
apiEndpoints.MapGet("/products/pages/{category}/{page}", ProductEndpoints.GetProductsPage);
apiEndpoints.MapPost("/products/create", ProductEndpoints.CreateProduct).RequireAuthorization();
apiEndpoints.MapGet("/products/product/{productId}", ProductEndpoints.GetProductById);
apiEndpoints.MapPost("/upload", PictureEndpoints.UploadPicture);

app.Run();
