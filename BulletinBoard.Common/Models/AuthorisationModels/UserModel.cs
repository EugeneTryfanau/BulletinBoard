using BulletinBoard.Common.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.Common.Models.AuthorisationModels
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Sex { get; set; }

        public DateTime BirthDate { get; set; }

        public Picture AvatarPictureID { get; set; }
    }
}
