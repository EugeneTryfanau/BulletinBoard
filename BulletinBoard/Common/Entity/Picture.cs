using System;
using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.Common.Entity
{
    public class Picture
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? PicturePath { get; set; }
    }
}
