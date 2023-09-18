using BulletinBoard.Common.Models.AuthorisationModels;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BulletinBoard.Data
{
    public class AutorizationDbContext : ApiAuthorizationDbContext<UserModel>
    {
        public AutorizationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }
    }
}