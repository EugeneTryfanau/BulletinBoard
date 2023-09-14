using BulletinBoard.DAL.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGet("/", (ApplicationContext db) => db.Users.ToList());

app.Run();