using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletinBoard.DAL.Entity
{
    public class CreateProductForm
    {
        public required string UserId { get; set; }

        public required string ProductName { get; set; }

        public required string ProductDescription { get; set; }

        public required int ProductCategoryId { get; set; }

        public required double ProductPrice { get; set; }

        public required bool ConditionIsNew { get; set; }




    }
}
