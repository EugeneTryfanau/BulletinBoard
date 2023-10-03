using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.DAL.Entity
{
    public class Picture
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? PicturePath { get; set; }
    }
}
