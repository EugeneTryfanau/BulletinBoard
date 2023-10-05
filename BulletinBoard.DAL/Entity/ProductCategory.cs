using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.DAL.Entity
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? CategoryName { get; set; }
    }
}
