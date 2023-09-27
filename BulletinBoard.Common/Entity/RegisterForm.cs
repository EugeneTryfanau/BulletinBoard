namespace BulletinBoard.Common.Entity
{
    public class RegisterForm
    {
        public required string Username { get; set; }

        public required string Password { get; set; }

        public required string ConfirmPassword { get; set; }
    }
}
