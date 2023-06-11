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

       
    }
}