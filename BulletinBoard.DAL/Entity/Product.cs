using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulletinBoard.DAL.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public int CategoryId { get; set; }

        public required ProductCategory Category { get; set; }

        public double Price { get; set; }

        public bool ConditionIsNew { get; set; }

        public required string UserId { get; set; }

        public required ApplicationUser User { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public List<Picture> ProductPicturies { get; set; } = new();
    }
}
