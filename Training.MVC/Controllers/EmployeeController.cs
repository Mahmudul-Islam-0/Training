using Microsoft.AspNetCore.Mvc;
using Training.DataAcces.Repository;
using Training.Models.DTO;
using Training.Models.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Training.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> EmployeeView()
        {
            ViewBag.Department = await unitOfWork.DepartmentRepo.GetAllAsync(); 

            var employees = await unitOfWork.EmployeeRepo.GetAllAsync(); 
            var employeeDtos = employees.Select(emp => new Employee
            {
                Id = emp.Id,
                Name = emp.Name,
                Address = emp.Address,
                City = emp.City,
                Phone = emp.Phone,
                DeptId = emp.DeptId
            }).ToList();

            return View(employeeDtos);
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeSave()
        {
            ViewBag.Department = await unitOfWork.DepartmentRepo.GetAllAsync(); 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeSave(Employee employeeDto)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Name = employeeDto.Name,
                    Address = employeeDto.Address,
                    City = employeeDto.City,
                    Phone = employeeDto.Phone,
                    DeptId = employeeDto.DeptId
                };

                await unitOfWork.EmployeeRepo.AddAsync(employee);
                await unitOfWork.Save();

                return RedirectToAction("EmployeeView");
            }

            return View(employeeDto);
        }

        [HttpGet]

        public async Task<IActionResult> Delete(string id)
        {
            var employee = await unitOfWork.EmployeeRepo.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }

            unitOfWork.EmployeeRepo.Delete(employee);
            await unitOfWork.EmployeeRepo.Save();

            return RedirectToAction(nameof(EmployeeView));
        }

    }
}
