using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SingleProduct(int id)
        {
            Console.WriteLine(id);  
            return View();
        }
    }
}
