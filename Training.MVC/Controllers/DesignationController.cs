using Microsoft.AspNetCore.Mvc;
using Training.DataAcces.Repository;
using Training.DataAcces.Repository.Interface;

namespace Training.MVC.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DesignationController( IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task <IActionResult> Index()
        {
            var ListDesig = await unitOfWork.DepartmentRepo.GetAll();
            return Ok(ListDesig);
        }

        public async Task<IActionResult> EmployeeList()
        {
            var ListDesig = await unitOfWork.EmployeeRepo.GetAll();
            return Ok(ListDesig);
        }
        public async Task<IActionResult> DesignationList()
        {
            var ListDesig = await unitOfWork.DesignationRepo.GetAll();
            return Ok(ListDesig);
        }
    }
}
