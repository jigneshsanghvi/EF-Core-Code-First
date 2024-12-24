using EFCoreCodeFirst.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFCoreCodeFirst.Controllers
{
    //[Authorize(Roles = "Admin")] // if comma separeted roles exist then OR condition will apply. To apply AND condition repeat statement with different roles.
    [Authorize(Policy = "MyAccessPolicy")]
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentDB;

        public HomeController(StudentDBContext studentDB)
        {
            this.studentDB = studentDB;
        }

        //[Route("")]
        public IActionResult Index()
        {
            return View(studentDB.Students.ToList());
        }

        public IActionResult ConfidentialData()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                std.Gender = ((Gender)int.Parse(std.Gender)).ToString();
                studentDB.Students.Add(std);
                studentDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(std);
        }
        public IActionResult Details(Guid id)
        {
            var obj = studentDB.Students.Find(id);
            return View(obj);
        }
        public IActionResult Edit(Guid id)
        {
            var obj = studentDB.Students.Find(id);
            Gender g = (Gender)(Enum.Parse(typeof(Gender), obj.Gender));
            obj.Gender = ((int)g).ToString();
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
            if (ModelState.IsValid)
            {
                std.Gender = ((Gender)int.Parse(std.Gender)).ToString();
                studentDB.Students.Update(std);
                studentDB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(std);
        }
        public IActionResult Delete(Guid id)
        {
            var obj = studentDB.Students.Find(id);
            studentDB.Students.Remove(obj);
            studentDB.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
