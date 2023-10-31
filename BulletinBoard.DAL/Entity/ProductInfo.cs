namespace BulletinBoard.DAL.Entity
{
    public class ProductInfo
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public double Price { get; set; }

        public bool ConditionIsNew { get; set; }
    }
}
