using BulletinBoard.Common.Models.AuthorisationModels;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BulletinBoard.Data
{
    public class AuthorizationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public AuthorizationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = Guid.NewGuid().ToString(), UserName = "Administrator", City = "NaN", PasswordHash = "Flzhk9483ELod".GetHashCode().ToString() });
        }
    }
}