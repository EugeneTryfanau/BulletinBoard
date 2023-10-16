namespace BulletinBoard.DAL.Entity
{
    public class ChangePasswordModel
    {
        public required string UserId { get; set; }
        public required string NewPassword { get; set; }
    }
}
