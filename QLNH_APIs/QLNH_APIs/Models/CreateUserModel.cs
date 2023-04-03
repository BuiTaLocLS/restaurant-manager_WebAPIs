using System.ComponentModel.DataAnnotations;
using System;

namespace QLNH_APIs.Models
{
    public class CreateUserModel
    {

        [MaxLength(100)]
        public string UserName { get; set; }
        public string DisplayName { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }
    }
}
