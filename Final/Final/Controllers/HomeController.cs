using Microsoft.AspNetCore.Mvc;
using Final.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        readonly StudentContext db;

        public HomeController(StudentContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult dbOutput(string name,string id)
        {
            return View(db.Students.ToList());
        }


        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(StudentModel student)
        {
            db.Entry(student).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("dbOutput");
        }
        public ActionResult DeleteStudent(int id)
        {
            StudentModel s = new StudentModel { Id = id };
            db.Entry(s).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("dbOutput");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            StudentModel del = db.Students.Find(id);
            if (del == null)
            {
                return HttpNotFound();
            }
            return View(del);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentModel b = db.Students.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Students.Remove(b);
            db.SaveChanges();
            return RedirectToAction("dbOutput");
        }
        [HttpGet]
        public ActionResult EditData(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            // Находим в бд студента
            StudentModel student = db.Students.Find(id);
            if (student != null)
            {
                // Создаем список данных которые можем изменить
                return View(student);
            }
            return RedirectToAction("dbOutput");
        }

        [HttpPost]
        public ActionResult EditData(StudentModel student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("dbOutput");
        }
        
    }
}