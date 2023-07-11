using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;
namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
      private EcommerceContext ctx = new EcommerceContext();

        public IActionResult Index()
        {

            var data = ctx.Products.ToList();
            return View(data);
        }
        public IActionResult Filter(string categories)
        {

            
            var data = ctx.Products.ToList();

            if (!string.IsNullOrEmpty(categories))
            {
                // Filter the products based on categories
                data = data.Where(p => p.Category.Equals(categories)).ToList();

            }

            return View(data);
        }
        public IActionResult PriceFilter(string price)
        {
            var data = ctx.Products.ToList();

            if (!string.IsNullOrEmpty(price) )
            {
                var value = decimal.Parse(price);
                // Filter the products based on price
                data = data.Where(p => p.Price < value).ToList();
            }

            return View(data);
        }
        public IActionResult Search(string search)
        {
            var data = ctx.Products.ToList();

            if (!string.IsNullOrEmpty(search))
            {
              
                data = data.Where(p => p.Description.Contains(search)).ToList();
            }

            return View(data);
        }

    }
}