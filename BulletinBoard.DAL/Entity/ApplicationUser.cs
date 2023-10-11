using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.DAL.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string? City { get; set; }

        public string? Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public List<Product> Products { get; set; } = new();

        public IdentityRole? Role { get; set; }
    }
}
