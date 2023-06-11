using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApplication3.Models;
namespace WebApplication3.Controllers
{
    public class ProductsController : Controller
    {
        private EcommerceContext ctx = new EcommerceContext();

        public IActionResult Index()
        {
            var data = ctx.Products.ToList();
            return View(data);
        }

        public IActionResult SingleProduct()
        {
            string url = Request.GetDisplayUrl();
            int startIndex = url.IndexOf("{") + 1;
            int endIndex = url.IndexOf("}");
            string idString = url.Substring(startIndex, endIndex - startIndex);
            int id = int.Parse(idString);
            var product = ctx.Products.Find(id);


            

            return View(product);
        }
    }
}

