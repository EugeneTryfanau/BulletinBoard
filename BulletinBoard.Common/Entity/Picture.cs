using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.Common.Entity
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PicturePath { get; set; }
    }
}
