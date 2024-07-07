using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteGiay.Models;
using WebsiteGiay.Filter;
namespace WebsiteGiay.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        ShoesDBContext Db = new ShoesDBContext();
        [MyAuthenFilter]
        public ActionResult Index()
        {
            List<ShoppingCart> listcart =Db.ShoppingCarts.ToList();
            return View(listcart);
        }
        [HttpPost]
        public ActionResult Insert(string productid,int size,int soluong)
        {
            if (productid!=null)
            {
                Product product = Db.Products.Find(productid);
                ShoppingCart cart = Db.ShoppingCarts.Where(row=>row.ProductId.Contains(productid)).FirstOrDefault();
                if (cart == null)
                {
                    cart =new ShoppingCart();
                    cart.ProductId = product.ProductId;
                    cart.Size = size;
                    cart.Soluong = soluong;
                    Db.ShoppingCarts.Add(cart);
                }
                else if (cart!=null && cart.Size!=size)
                {
                    cart = new ShoppingCart();
                    cart.ProductId = product.ProductId;
                    cart.Size = size;
                    cart.Soluong = soluong;
                    Db.ShoppingCarts.Add(cart);
                }
                else
                {
                    cart.Soluong += soluong;
                }
                Db.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
            return RedirectToAction("ProductDetail", "Home", new { @id = productid });
        }
        public ActionResult Update(string productid,int soluong)
        {
            if (soluong>0)
            {
                ShoppingCart item = Db.ShoppingCarts.Where(row=>row.ProductId.Contains(productid)).FirstOrDefault();
                if (item != null)
                {
                    item.Soluong = soluong;
                }
                Db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            ShoppingCart item = Db.ShoppingCarts.Where(row=>row.ProductId.Contains(id)).FirstOrDefault();
            Db.ShoppingCarts.Remove(item);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}