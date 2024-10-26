using Microsoft.AspNetCore.Mvc;
using Training.DataAcces.Repository;
using Training.Models.DTO; // Make sure to include the DTO namespace
using Training.Models.Entity; // Assuming you still have an Employee entity

namespace Training.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // Action to view the list of employees
        public async Task<IActionResult> EmployeeView()
        {
            ViewBag.Department = await unitOfWork.DepartmentRepo.ToListAsync();

            // Fetch the employees and map them to EmpListDTO
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

            return View(employeeDtos); // Pass the list of DTOs to the view
        }

        // Action to show the form for saving a new employee
        public IActionResult EmployeeSave()
        {
            return View(); // Return the empty form for a new employee
        }

        // Action to handle the form submission for saving a new employee
        [HttpPost]
        public async Task<IActionResult> EmployeeSave(Employee employeeDto)
        {

            if (ModelState.IsValid)
            {
                // Map DTO to Entity (assuming you have an Employee entity)
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
                await unitOfWork.EmployeeRepo.Save(); // Save changes
                return RedirectToAction("EmployeeView"); // Redirect to the employee list after saving
            }
            return View(employeeDto); // Return the same view with the model if validation fails
        }
    }
}
