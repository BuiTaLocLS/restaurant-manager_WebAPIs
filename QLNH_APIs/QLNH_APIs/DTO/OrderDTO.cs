using QLNH_APIs.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace QLNH_APIs.DTO
{
    public class OrderDTO
    {
        [Key]
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public bool Voided { get; set; }
        public double TotalPrice { get; set; }
        public double PaidAmount { get; set; }
        public IList<OrderItemDTO> OrderItem { get; set; }
    }
}
