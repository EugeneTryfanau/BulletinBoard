﻿using BulletinBoard.Common.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.DAL.Common.Models.AuthorisationModels
{
    public class UserModel : IdentityUser
    {
        [Required]
        public string? City { get; set; }

        public string? Sex { get; set; }

        public DateTime BirthDate { get; set; }

        public Picture? AvatarPictureID { get; set; }
    }
}
