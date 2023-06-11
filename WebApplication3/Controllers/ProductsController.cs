using Microsoft.AspNetCore.Mvc;
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

        public IActionResult SingleProduct(int id)
        {
            Console.WriteLine(id);  
            return View();
        }
    }
}
