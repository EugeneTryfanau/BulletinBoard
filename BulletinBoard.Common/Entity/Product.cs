using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletinBoard.Common.Entity
{
    public  class Product
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description {  get; set; }

        [Required]
        public int Category { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int PriceTypeId { get; set; }

        [Required]
        public bool ConditionIsNew { get; set; }

        //100% нужен, но пока посмотрю можно ли уменьшить таблицу
        //public int UserID { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }


        //думаю пока фото через base64 передавать клиенту, посмотрю может по другому можно
        public List<string> ProductPicturies { get; set; } 
    }
}
