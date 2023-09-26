using BulletinBoard;

var builder = WebApplication.CreateBuilder(args);

var app = builder.BuildWithSPA();

var apiEndpoints = app.MapGroup("/api");

apiEndpoints.MapGet("/", () => "Hello World");

app.Run();
