using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PIN_WebAPP.Models
{
    public class ShopingCart
    {
        public ShopingCart()
        {
            Count = 1;
        }
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        [NotMapped]
        [ForeignKey("User")]
        public virtual User User { get; set; }

        public int ProductId { get; set; }

        [NotMapped]
        [ForeignKey("Product")]
        public virtual Product Product { get; set; }

        [Range(1,int.MaxValue, ErrorMessage = "Nan")]
        public int Count { get; set; }
    }
}
