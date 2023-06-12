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
        private readonly EcommerceContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(EcommerceContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
        public IActionResult Create(string title, string category, string description, decimal price, IFormFile image)
        {
            Console.WriteLine("here ");
                string imageUrl = null;
            return RedirectToAction("Index", "Home"); // Redirect to the home page or any other desired action

            // Process the uploaded image
            if (image!= null && image.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "productImages");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    imageUrl = "/productImages/" + uniqueFileName; // Save the URL in the database

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
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

            return View(); // Return the view with the invalid form
        }
    }
}
