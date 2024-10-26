using Microsoft.AspNetCore.Mvc;
using Training.DataAcces.Repository;
using Training.Models.DTO; 
using Training.Models.Entity; 
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
            ViewBag.Department = await unitOfWork.DepartmentRepo.ToListAsync();

            var employees = await unitOfWork.EmployeeRepo.GetAll();
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

        public IActionResult EmployeeSave()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeSave(Employee employeeDto)
        {

            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = employeeDto.Id,
                    Name = employeeDto.Name,
                    Address = employeeDto.Address,
                    City = employeeDto.City,
                    Phone = employeeDto.Phone,
                    DeptId = employeeDto.DeptId
                };

                await unitOfWork.EmployeeRepo.AddAsync(employee);
                await unitOfWork.EmployeeRepo.Save(); 
                return RedirectToAction("EmployeeView"); 
            }
            return View(employeeDto); 
        }
    }
}
