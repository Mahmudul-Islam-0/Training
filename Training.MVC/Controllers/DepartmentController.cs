using Microsoft.AspNetCore.Mvc;
using Training.DataAcces.Repository;
using Training.Models.Entity;

namespace Training.MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DepartmentView()
        {
            var departments = await unitOfWork.DepartmentRepo.GetAll(); // Fetch departments
            return View(departments); // Pass the list of departments to the view
        }

        // Action to show the form for saving a new department
        public IActionResult DepartmentSave()
        {
            return View(); // Return the empty form for new department
        }

        // Action to handle the form submission for saving a new department
        [HttpPost]
        public async Task<IActionResult> DepartmentSave(Department department) // Assuming Department is your model
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.DepartmentRepo.AddAsync(department);
                await unitOfWork.DepartmentRepo.Save(); // Save changes
                return RedirectToAction("DepartmentView"); // Redirect to the department list after saving
            }
            return View(department); // Return the same view with the model if validation fails
        }
    }
}
