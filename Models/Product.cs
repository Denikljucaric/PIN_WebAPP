using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PIN_WebAPP.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Product Code")]
        [Required]
        public string Name { get; set; }
        public bool isActive { get; set; }
        public bool isSale { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="Price shuld be greater then $(1)")]
        public double FirstPrice { get; set; }
        public double Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId {get;set;}
        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }
        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }


    }
}
