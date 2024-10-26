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
            var designations = await unitOfWork.DesignationRepo.GetAll(); // Fetch designations
            return View(designations); // Pass the list to the view
        }

        // Action to show the form for creating a new designation
        public IActionResult DesignationSave()
        {
            return View(); // Return the view for creating a new designation
        }

        // Action to handle the form submission for creating a new designation
        [HttpPost]
        public async Task<IActionResult> DesignationSave(Designation designation) // Assuming Designation is your model
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.DesignationRepo.AddAsync(designation);
                await unitOfWork.DesignationRepo.Save(); // Save changes
                return RedirectToAction("DesignationView"); // Redirect to the designation list after saving
            }
            return View(designation); // Return the same view with the model if validation fails
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
