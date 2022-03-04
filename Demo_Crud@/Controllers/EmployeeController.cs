using Demo_Crud_.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Crud_.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context;

        public EmployeeController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var emp = context.Employees.ToList();
            return View(emp);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee Model)
        {
            var emp = new Employee()
            {
                Id = Model.Id,
                FirstName = Model.FirstName,
                LastName = Model.LastName,
                Salary = Model.Salary,
                Gender = Model.Gender,
            };

            context.Employees.Add(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.Id == Id);
            context.Employees.Remove(emp);

            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var update = context.Employees.SingleOrDefault(e => e.Id == Id);
         
            return View(update);
        }
     

        [HttpPost]
        public IActionResult Edit(Employee Model)
        {
            //var emp = context.Employees.Update(Model);




            var emp = new Employee()
            {
                Id = Model.Id,
                FirstName = Model.FirstName,
                LastName = Model.LastName,
                Salary = Model.Salary,
                Gender = Model.Gender,

            };

            context.Employees.Update(emp);

                context.SaveChanges();
              return RedirectToAction("Index");
        }
    }
}
