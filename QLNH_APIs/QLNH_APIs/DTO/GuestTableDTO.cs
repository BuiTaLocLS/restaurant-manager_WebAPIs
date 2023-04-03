using QLNH_APIs.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace QLNH_APIs.DTO
{
    public class GuestTableDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public StatusDTO Status { get; set; }
        public LocationDTO Location { get; set; }
        public GuestDTO Guest { get; set; }
        public RestaurantDTO Restaurant { get; set; }
        public UserDTO CreatedUser { get; set; }
        public UserDTO UpdatedUser { get; set; }
    }
}
