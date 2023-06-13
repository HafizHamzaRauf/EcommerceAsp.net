using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductsController : Controller
    {
        private readonly EcommerceContext _context = new EcommerceContext();

      

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
        public IActionResult Create(string title, string category, string description, decimal price, IFormFile image)
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
                return RedirectToAction("AddProduct", "Profile"); // Redirect to the home page or any other desired action

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

            return RedirectToAction("Index", "Home"); // Redirect to the home page or any other desired action
        }



    }
}
