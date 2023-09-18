using BulletinBoard.DAL.Context;
using BulletinBoard.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

UserModelRepository users = new UserModelRepository();

app.MapGet("/", async () => await users.GetAllAsync());

app.Run();