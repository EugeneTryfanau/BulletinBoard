namespace BulletinBoard.Endpoints
{
    public class LogoutEndpoint
    {
        public static IResult Handler() => Results.SignOut(authenticationSchemes: new List<string>() { "cookie" });
    }
}
