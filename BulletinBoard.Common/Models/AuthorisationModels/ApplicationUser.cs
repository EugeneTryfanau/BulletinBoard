using BulletinBoard.Common.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.Common.Models.AuthorisationModels
{
    [Keyless]
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public string? City { get; set; }

        public string? Sex { get; set; }

        public DateTime BirthDate { get; set; }

        public Picture? AvatarPictureID { get; set; }
    }
}
