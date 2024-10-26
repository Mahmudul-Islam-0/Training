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
            var departments = await unitOfWork.DepartmentRepo.GetAll(); 
            return View(departments); 
        }

        public IActionResult DepartmentSave()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> DepartmentSave(Department department) 
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.DepartmentRepo.AddAsync(department);
                await unitOfWork.DepartmentRepo.Save(); 
                return RedirectToAction("DepartmentView"); 
            }
            return View(department); 
        }
    }
}
