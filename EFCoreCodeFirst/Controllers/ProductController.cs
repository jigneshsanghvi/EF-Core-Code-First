using EFCoreCodeFirst.Models;
using EFCoreCodeFirst.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace EFCoreCodeFirst.Controllers
{
    public class ProductController : Controller
    {
        private readonly StudentDBContext context;
        IWebHostEnvironment env;
        public ProductController(StudentDBContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env; 
        }
        public IActionResult Index()
        {
            return View(context.Products.ToList());
        }
        public IActionResult Create(ProductViewModel prod)
        {
            string fileName = "";
            if(prod.photo != null)
            {
                string folderPath = Path.Combine(env.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "_" + prod.photo.FileName;
                string filePath = Path.Combine(folderPath, fileName);
                prod.photo.CopyTo(new FileStream(filePath, FileMode.Create));

                Product p = new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = prod.Name,
                    Price = prod.Price,
                    ImagePath = fileName
                };

                context.Products.Add(p);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Message = "Please select Image";
            return View();
        }
    }
}
