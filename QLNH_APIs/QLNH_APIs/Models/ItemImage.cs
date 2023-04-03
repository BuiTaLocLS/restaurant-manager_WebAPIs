using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QLNH_APIs.Models
{
    [Table("ItemImage")]
    public class ItemImage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Base64 { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User UpdatedUser { get; set; }
        //public virtual Item Item{ get; set; }
    }
}
