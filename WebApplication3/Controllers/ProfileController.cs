using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProfileController : Controller
    {
		EcommerceContext _context = new EcommerceContext();
        public IActionResult Index()
		{
            var orders = _context.Orders
   .Join(_context.Users, o => o.UserId, u => u.Id, (o, u) => new OrderViewModel
   {
       OrderId = o.OrderId,
       Status = o.Status,
       Username = u.Username,
       Payment = o.Payment,
       Quantity = o.Quantity
   })
   .ToList();

            return View(orders);
        }
        public IActionResult AddProduct()
        {
            return View();
        }
    }
}
