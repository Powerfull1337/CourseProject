using CourseProject.Data;
using CourseProject.Models.Domain;
using CourseProject.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly CRUDContext crudContext;

        public EmployeesController(CRUDContext crudContext)
        {
            this.crudContext = crudContext;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var emploees = await crudContext.Employees.ToListAsync();
            return View(emploees);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                Department = addEmployeeRequest.Department,
                DateOfBirth = addEmployeeRequest.DateOfBirth,
                Image = addEmployeeRequest.Image,
                Description = addEmployeeRequest.Description,
            };
            await crudContext.Employees.AddAsync(employee);
            await crudContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await crudContext.Employees.FirstOrDefaultAsync(x => x.Id == id);


            if (employee != null)
            {
                var viewmodel = new UpdateEmployeeViewModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    Department = employee.Department,
                    DateOfBirth = employee.DateOfBirth,
                    Image = employee.Image,
                    Description = employee.Description,
                };
                return await Task.Run(() => View("View", viewmodel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var employee = await crudContext.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Department = model.Department;
                employee.Image = model.Image;
                employee.Description = model.Description; 
                await crudContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {
            var employee = await crudContext.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                crudContext.Employees.Remove(employee);
                await crudContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
