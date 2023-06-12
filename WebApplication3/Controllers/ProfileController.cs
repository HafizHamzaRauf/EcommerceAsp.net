using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }
    }
}
