using System.ComponentModel.DataAnnotations;
using System;
using QLNH_APIs.Models;

namespace QLNH_APIs.DTO
{
    public class OrderItemDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public bool Voided { get; set; }
        public double SalePrice { get; set; }
        public ItemDTO Item { get; set; }
        public int Quantity { get; set; }
        public  RestaurantDTO Restaurant { get; set; }
        public  OrderDTO Order { get; set; }
    }
}
