using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.DAL.Entity
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        public required string PublicId { get; set; }

        public required string PhotoPath { get; set; }

        public bool IsPrimary { get; set; }

        public int ProductId { get; set; }
    }
}
