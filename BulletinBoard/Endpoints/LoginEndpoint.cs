using BulletinBoard.Common.Entity;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace BulletinBoard.Endpoints
{
    public class LoginEndpoint
    {
        public static IResult Handler(LoginForm form) =>
            Results.SignIn(
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim("userId", Guid.NewGuid().ToString()), new Claim("username", form.Username)
                        },
                        "cookie")
                ),
                properties: new AuthenticationProperties() { IsPersistent = true },
                authenticationScheme: "cookie");
    }
}
