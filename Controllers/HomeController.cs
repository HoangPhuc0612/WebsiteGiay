using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteGiay.Models;

namespace WebsiteGiay.Controllers
{
    public class HomeController : Controller
    {
        ShoesDBContext Db = new ShoesDBContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Products(string search = "", string sort = "", string gender = "", string category = "", int page = 1, string price = "")
        {
            //search
            List<Product> products = Db.Products.Where(row => row.ProductName.Contains(search)).ToList();
            ViewBag.Search = search;
            //Sort theo brand id
            products = products.Where(row => row.Brand.BrandName.Contains(sort)).ToList();
            ViewBag.Sort = sort;
            //Sort theo Gender
            products = products.Where(row => row.Gender.Contains(gender)).ToList();
            ViewBag.Gender = gender;
            //Sort theo Category
            products = products.Where(row => row.Category.CategoryName.Contains(category)).ToList();
            ViewBag.Cate = category;
            //Sort theo Price
            if (string.Compare(price,"500-600k")==0)
            {
                ViewBag.Price = price;
                products = products.Where(row => row.Price >= 500000).ToList();
                products = products.Where(row => row.Price <= 600000).ToList();
            }    
            else if (string.Compare(price, "600-900k") == 0)
            {
                ViewBag.Price = price;
                products = products.Where(row => row.Price >= 600000).ToList();
                products = products.Where(row => row.Price <= 900000).ToList();
            }
            else if(string.Compare(price,">1.000.000k")==0)
            {
                ViewBag.Price = price;
                products = products.Where(row => row.Price >= 1000000).ToList();
            }
            ViewBag.ListCate = Db.Categories.ToList();
            ViewBag.ListBrand = Db.Brands.ToList();
            //Paging
            int product_perpage = 6;

            if (products.Count < product_perpage)
            {
                ViewBag.NoPaging = 1;
            }
            else
            {
                ViewBag.NoPaging = 0;
            }
            int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(product_perpage)));
            int skippage = (page - 1) * product_perpage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = noOfPages;
            products = products.Skip(skippage).Take(product_perpage).ToList();
            return View(products);
        }
        public ActionResult ProductDetail(string id)
        {
            //Product product = Db.Products.Where(row => row.ProductId.Contains(id)).FirstOrDefault();
            Product product = Db.Products.Find(id);
            return View(product);
        }
        public ActionResult ProductBrand()
        {
            List<Brand> listBrand = Db.Brands.ToList();
            return View(listBrand);
        }
    }
}