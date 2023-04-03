using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using QLNH_APIs.Models;

namespace QLNH_APIs.DTO
{
    public class ItemDTO
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FoodId")]
        public  FoodDTO Food { get; set; }

        [ForeignKey("SizeId")]
        public  SizeDTO Size { get; set; }


        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }

        public RestaurantDTO Restaurant { get; set; }
        public UserDTO CreatedUser { get; set; }
        public UserDTO UpdatedUser { get; set; }
    }
}
