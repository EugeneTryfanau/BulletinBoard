using BulletinBoard.Common.Entity;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BulletinBoard.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<ProductCategory> Categories { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Picture> Pictures { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
            Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    byte[] salt = new byte[128 / 8];
        //    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //    password: "password",
        //    salt: salt,
        //    prf: KeyDerivationPrf.HMACSHA256,
        //    iterationCount: 100000,
        //    numBytesRequested: 256 / 8));
        //    modelBuilder.Entity<ApplicationUser>().HasData(
        //        new ApplicationUser { UserName = "admin", PasswordHash = hashed });
        //}
    }
}