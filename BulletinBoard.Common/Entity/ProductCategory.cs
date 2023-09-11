﻿using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.Common.Entity
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public ProductCategory ParentId { get; set; }
    }
}