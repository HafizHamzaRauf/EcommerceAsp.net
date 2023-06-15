using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Hubs; // Assuming the SignalR hub class is in the "Hubs" folder

namespace WebApplication3.Controllers
{
    public class ProductsController : Controller
    {
        private readonly EcommerceContext _context = new EcommerceContext();
        private readonly IHubContext<ProductHub> _productHubContext;

        public ProductsController( IHubContext<ProductHub> productHubContext)
        {
            _productHubContext = productHubContext;
        }

        public IActionResult Index()
        {
            var data = _context.Products.ToList();
            return View(data);
        }

        public IActionResult SingleProduct()
        {
            string url = Request.GetDisplayUrl();
            int startIndex = url.IndexOf("{") + 1;
            int endIndex = url.IndexOf("}");
            string idString = url.Substring(startIndex, endIndex - startIndex);
            int id = int.Parse(idString);
            var product = _context.Products.Find(id);

            return View(product);
        }

        [HttpPost]
        public async Task Create(string title, string category, string description, decimal price, IFormFile image)
        {
            string imageUrl = null;
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "productImages");
            string uniqueFileName = Guid.NewGuid().ToString() + ".jpg";
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            imageUrl = "/productImages/" + uniqueFileName; // Save the URL in the database

            try
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error message
                Console.WriteLine($"Error copying image file: {ex.Message}");
                // You can choose to return an error view or redirect to an error page
                RedirectToAction("AddProduct", "Profile"); // Redirect to the home page or any other desired action
            }

            var product = new Product
            {
                Title = title,
                Category = category,
                Description = description,
                Price = price,
                ImageUrl = imageUrl
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            // Notify clients to update their products
            await _productHubContext.Clients.All.SendAsync("SendProductUpdate");
        }
    }
}
