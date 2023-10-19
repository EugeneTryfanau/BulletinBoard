namespace BulletinBoard.DAL.Entity
{
    public class RegisterForm
    {
        public required string Email { get; set; }

        public required string Username { get; set; }

        public string? City { get; set; }

        public string? Gender { get; set; }

        public string? PhoneNumber { get; set; }

        public string? BirthdayDate { get; set; }

        public required string Password { get; set; }

        public required string ConfirmPassword { get; set; }
    }
}
