using QLNH_APIs.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace QLNH_APIs.DTO
{
    public class ItemImageDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Base64 { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public RestaurantDTO Restaurant { get; set; }
        public UserDTO CreatedUser { get; set; }
        public UserDTO UpdatedUser { get; set; }
        //public ItemDTO Item { get; set; }
    }
}
