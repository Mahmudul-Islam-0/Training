using Microsoft.AspNetCore.Mvc;
using Training.DataAcces.Repository;
using Training.DataAcces.Repository.Interface;
using Training.Models.Entity;

namespace Training.MVC.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DesignationController( IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> DesignationView()
        {
            var designations = await unitOfWork.DesignationRepo.GetAll(); 
            return View(designations); 
        }

        public IActionResult DesignationSave()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> DesignationSave(Designation designation) 
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.DesignationRepo.AddAsync(designation);
                await unitOfWork.DesignationRepo.Save(); 
                return RedirectToAction("DesignationView"); 
            }
            return View(designation); 
        }

        [HttpGet]

        public async Task<IActionResult> Delete (string id)
        {
            var designation = await unitOfWork.DesignationRepo.GetById(id);
            if (designation is null)
            {
                return NotFound();
            }

            unitOfWork.DesignationRepo.Delete(designation);
            await unitOfWork.DesignationRepo.Save();

            return RedirectToAction(nameof(DesignationView));
        }



    }
}
