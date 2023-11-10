using BulletinBoard.DAL.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace BulletinBoard.Tests
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    b => b.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                services.Remove(dbContextDescriptor);

                var dbConnectionDescriptor = services.SingleOrDefault(
                    b => b.ServiceType == typeof(DbConnection));

                services.Remove(dbConnectionDescriptor);

                services.AddSingleton<DbConnection>(conteiner =>
                {
                    var connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=BulletinBoard;Trusted_Connection=True;MultipleActiveResultSets=true");
                    connection.Open();

                    return connection;
                });

                services.AddDbContext<ApplicationDbContext>((conteiner, options) =>
                {
                    var connection = conteiner.GetRequiredService<DbConnection>();
                    options.UseSqlServer(connection);
                });
            });

            builder.UseEnvironment("Development");
        }
    }
}
