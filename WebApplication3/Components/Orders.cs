using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using System.Linq;

namespace WebApplication3.ViewComponents
{
    public class Orders: ViewComponent
    {
        private readonly EcommerceContext _context = new EcommerceContext();


        public IViewComponentResult Invoke()
        {
            var orders = _context.Orders
                .Join(_context.Users, o => o.UserId, u => u.Id, (o, u) => new
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
    }
}
