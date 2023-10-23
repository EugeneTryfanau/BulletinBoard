﻿using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.DAL.Entity
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        public string? PicturePath { get; set; }

        public string? PublicId { get; set; }

        public bool? IsPrimary { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
