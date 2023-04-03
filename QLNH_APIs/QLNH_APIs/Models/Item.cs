using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_APIs.Models
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FoodId")]
        public virtual Food Food{ get; set; }

        [ForeignKey("SizeId")]
        public virtual Size Size { get; set; }


        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User UpdatedUser { get; set; }
    }
}
