using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductController: Controller
    {
        
        public IActionResult ProductsList()
        {

            var category = new Category
            {
                Name = "Electronics",
                Discount = 10,
                Description = "Devices and gadgets"
            };

            var product = new Product
            {
                Name = "Smartphone",
                Price = 699.99M,
                Description = "High-end smartphone with AMOLED display.",
                ManufactureDate = new DateTime(2023, 6, 15),
                Category = category 
            };

            ViewBag.Description = product.Description;
            ViewData["ManufactureDate"] = product.ManufactureDate.ToString("dd.MM.yyyy");

            return View(product);
         
        }
    }
}
