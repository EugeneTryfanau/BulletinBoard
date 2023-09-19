using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.Common.Entity
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public ProductCategory? Category { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public bool ConditionIsNew { get; set; }

        [Required]
        public string? ApplicationUserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        public DateTime CreationDate { get; set; }

        public List<Picture> ProductPicturies { get; set; } = new();
    }
}
