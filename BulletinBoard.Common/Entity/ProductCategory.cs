using System;
using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.Common.Entity
{
    public class ProductCategory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public ProductCategory ParentId { get; set; }
    }
}
