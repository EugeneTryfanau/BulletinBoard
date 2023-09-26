using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.Common.Entity
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public override string Id { get => base.Id; set => base.Id = value; }

        public string? City { get; set; }

        public string? Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public Picture? AvatarPictureID { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}
