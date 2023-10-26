using Microsoft.AspNetCore.Identity;

namespace BulletinBoard.DAL.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string? City { get; set; }

        public string? Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}
