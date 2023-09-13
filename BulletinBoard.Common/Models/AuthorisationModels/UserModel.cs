using BulletinBoard.Common.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.Common.Models.AuthorisationModels
{
    public class UserModel: IdentityUser
    {
        [Required]
        public string City { get; set; }

        public string Sex { get; set; }

        public DateTime BirthDate { get; set; }

        public Picture AvatarPictureID { get; set; }
    }
}
