using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebsiteGiay.Models
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }

        [Required(ErrorMessage = "Product name cannot be blank.")]
        [RegularExpression(@"^[A-Za-z 0-9]*$",ErrorMessage = "Cannot use special characters in product name.")]
        [MinLength(3,ErrorMessage = "Product name should contain at least 3 characters.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price cannot be blank.")]
        [DisplayFormat(DataFormatString = "{0:0,0 VND}")]
        [Range(300000,100000000,ErrorMessage = "Price should be in between 300.000 and 100.000.000.")]
        public int Price { get; set; }

        public Nullable<int> Discount {get; set; }

        [Required]
        public string Status { get; set; }

        public string ImageURL { get; set; }

        [Required]
        public int BrandID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Size {  get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category{ get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}