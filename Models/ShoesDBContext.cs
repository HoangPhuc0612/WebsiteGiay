using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebsiteGiay.Models
{
    public class ShoesDBContext:DbContext
    {
        public ShoesDBContext():base("NewConnection"){ }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set;}
    }
}