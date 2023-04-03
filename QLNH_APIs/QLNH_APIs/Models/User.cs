using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QLNH_APIs.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
      
        [MaxLength(100)]
        public string UserName { get; set; }
        public string DisplayName { get; set; }

        [JsonIgnore]
       
        [MaxLength(100)]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public bool OffDuty { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set;}

        [NotMapped]
        public IEnumerable<User> CreatedUser { get; set; }
        public IEnumerable<User> UpdatedUser { get; set; }

        public static implicit operator DateTime(User v)
        {
            throw new NotImplementedException();
        }
    }
}
