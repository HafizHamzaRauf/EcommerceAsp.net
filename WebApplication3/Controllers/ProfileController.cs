using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
