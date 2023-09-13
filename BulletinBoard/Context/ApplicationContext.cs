using BulletinBoard.DAL.Common.Models.AuthorisationModels;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BulletinBoard.DAL.Context
{
    public class ApplicationContext: ApiAuthorizationDbContext<UserModel>
    {
        public ApplicationContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }
    }
}
