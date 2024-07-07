using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebsiteGiay.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        //public string UserID { get; set; }
        public string ProductId { get; set; }
        public int Size { get; set; }
        public int Soluong { get; set; }
        public virtual Product Product { get; set; }
    }
}