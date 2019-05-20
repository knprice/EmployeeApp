using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        static List<Employee> _empList;

        public ActionResult ListEmployees()
        {
            
            if(_empList == null)
            {
                _empList = new List<Employee>();
                _empList.Add(new Employee
                {
                    id = 1,
                    Address = "123 Main",
                    Name = "John",
                    Phone = "123-123-1234"
                });
                _empList.Add(new Employee
                {
                    id = 2,
                    Address = "3018 S Newton",
                    Name = "Pedro",
                    Phone = "405-223-4434"
                });
                _empList.Add(new Employee
                {
                    id = 3,
                    Address = "456 W Auto Drive",
                    Name = "Julie",
                    Phone = "479-232-2122"
                });
            }
            
            return View(_empList);

            
        }

            // GET Create Employee View
            public ActionResult CreateEmployee()
        {
            return View();
        }
        // Create a new employee
        [HttpPost]
        public ActionResult CreateEmployee(Employee emp)
        {
            try
            {
                emp.id = _empList.Count + 1;
                _empList.Add(emp);
                return RedirectToAction("ListEmployees");
            }
            catch
            {
                return View();
            }
        }

        // GET: Load Edit Employee page
        public ActionResult EditEmployee(int id)
        {
            return View(_empList.Where(e => e.id == id).FirstOrDefault());
        }

        //Update the employee list
        [HttpPost]
        public ActionResult EditEmployee(Employee emp)
        {
            try
            {
                // TODO: Add update logic here
                _empList[_empList.FindIndex(e => e.id == emp.id)] = emp;

                return RedirectToAction("ListEmployees");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult DeleteEmployee(int id)
        {
            return View(_empList.Where(e => e.id == id).FirstOrDefault());
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult DeleteEmployee(Employee emp)
        {
            try
            {
                // TODO: Add delete logic here
                _empList.RemoveAt(_empList.FindIndex(e => e.id == emp.id));
                return RedirectToAction("ListEmployees");
            }
            catch
            {
                return View();
            }
        }
    }
}