using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletinBoard.DAL.Entity
{
    public class ProductForm: Product
    {
        public List<string> picPathes { get; set; } = new List<string>();
    }
}
