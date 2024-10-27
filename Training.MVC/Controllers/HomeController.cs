using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Training.DataAcces;
using Training.DataAcces.Repository;
using Training.DataAcces.Repository.Interface;
using Training.Models.DTO;
using Training.Models.Entity;
using Training.MVC.Models;

namespace Training.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TrainingDBContext db;
        private readonly IUnitOfWork unitOfWork;
        

        public HomeController(ILogger<HomeController> logger, TrainingDBContext db, IUnitOfWork unitOfWork) 
        {
            _logger = logger;
            this.db = db;
            this.unitOfWork = unitOfWork;
            
        }

        public async Task<IActionResult> EmployeeList()
        {
            var empList = await unitOfWork.EmployeeRepo.GetIncludedept();
            return Ok(empList);
        }
            public async Task<IActionResult> Index(string id, string name)
        {
            //var department = new Department()
            //{
            //    CreatedDate = DateTime.Now,
            //    Id = "0",
            //    Name = "GTR",
            //    IsDeleted = false,
            //    UpdatedBy = "JM",
            //};
            //var department1 = new Department()
            //{
            //    CreatedDate = DateTime.Now,
            //    Id = "1",
            //    Name = "GTR",
            //    IsDeleted = false,
            //    UpdatedBy = "JM",
            //};
            //var department2 = new Department()
            //{
            //    CreatedDate = DateTime.Now,
            //    Id = "2",
            //    Name = "GTR",
            //    IsDeleted = false,
            //    UpdatedBy = "JM",
            //};
            //var department3 = new Department()
            //{
            //    CreatedDate = DateTime.Now,
            //    Id = "3",
            //    Name = "GTR",
            //    IsDeleted = false,
            //    UpdatedBy = "JM",
            //};
            //List<Department> DepartmentList = new List<Department>();
            //DepartmentList.Add(department);
            //DepartmentList.Add(department1);
            //DepartmentList.Add(department2);
            //DepartmentList.Add(department3); 
            //if (id != 0)
            //{
            //    DepartmentList = DepartmentList.Where(x => x.Id.ToLower() == id.ToString()).ToList();

            //}
            var query = db.Departments.AsQueryable();
            if (!string.IsNullOrEmpty(id))
            {
                query = query.Where(x => x.Id == id);

            }
            var DepartmentList = await query.ToListAsync();

            return View(DepartmentList);
        }

        public async Task<IActionResult> TotalDepartment(string id)
        {
            var total = await db.Departments.Where(x => x.Id == id).AnyAsync();

            return Ok(total);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var dept = await db.Departments.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (dept is null)
            {
                return NotFound();
            }
             
            return Ok(dept);
        }

        public async Task<IActionResult> GetByIdView(string id)
        {
            var total = await db.Departments.CountAsync();
            var dept = await db.Departments.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (dept is null)
            {
                return NotFound();
            }
            ViewBag.Total = total;

            return View(dept);
        }

        public async Task<IActionResult> DepartmentList2()
        {
            var department = await db.Departments.Select(x => new DeptListDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return Ok(department);
        }

        [HttpGet]
        public async Task<IActionResult> DepartmentSave(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }

            var dept = await db.Departments.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (dept is null)
            {
                return NotFound();
            }

            return View(dept);
        }

        [HttpPost]
        public async Task<IActionResult> DepartmentSave(DeptListDTO model)
        {
            if (!string.IsNullOrEmpty(model.Id))
            {
                var dept = await unitOfWork.DepartmentRepo.GetById(model.Id);
                if (dept is null)
                {
                    return NotFound();
                }
                dept.Name = model.Name;

                await unitOfWork.DepartmentRepo.Save();
                unitOfWork.DepartmentRepo.Edit(dept);
                return RedirectToAction(nameof(Index));
            }

            var department = new Department()
            {
                Name = model.Name
            };
            unitOfWork.DepartmentRepo.Add(department);
            await unitOfWork.DepartmentRepo.Save();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> DepartmentDelete(string id)
        {
            var dept = await db.Departments.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (dept is null)
            {
                return NotFound();
            }

            db.Remove(dept);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task <IActionResult> Privacy(string id, string name)
        {
            var query = db.Employees.AsQueryable();
            if (!string.IsNullOrEmpty(id))
            {
                query = query.Where(x => x.Id == id);

            }
            var EmployeeList = await query.ToListAsync();

            return View(EmployeeList);
        }

        public async Task<IActionResult> TotalEmployee(string id)
        {
            //var total = await db.Employees.CountAsync();
            var total = await db.Employees.Where(x => x.Id == id).AnyAsync();

            return Ok(total);
        }

        public async Task<IActionResult> EmpGetById(string id)
        {
            var emp = await db.Employees.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (emp is null)
            {
                return NotFound();
            }

            return Ok(emp);
        }

        public async Task<IActionResult> EmpGetByIdView(string id)
        {
            var total = await db.Employees.CountAsync();
            var emp = await db.Employees.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (emp is null)
            {
                return NotFound();
            }
            ViewBag.Total = total;

            return View(emp);
        }

        public async Task<IActionResult> EmployeeList2()
        {
            var emp = await db.Employees.Select(x => new EmpListDTO
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                Phone = x.Phone
            }).ToListAsync();
            return Ok(EmployeeList2);
        }


        [HttpGet]
        public async Task<IActionResult> EmployeeSave(string id)
        {
            ViewBag.Department = await db.Departments.ToListAsync();
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }
            
            var emp = await db.Employees.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (emp is null)
            {
                return NotFound();
            }

            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeSave(EmpListDTO model)
        {

            var departmentExists = await db.Departments.AnyAsync(d => d.Id == model.DeptId);
            if (!departmentExists)
            {

                ModelState.AddModelError("DeptId", "The selected department does not exist.");
                return View(model);
            }

            if (!string.IsNullOrEmpty(model.Id))
            {

                var edit = await db.Employees.Where(x => x.Id == model.Id).SingleOrDefaultAsync();
                if (edit is null)
                {
                    return NotFound();
                }
                edit.Name = model.Name;
                edit.Address = model.Address;
                edit.City = model.City;
                edit.Phone = model.Phone;
                edit.DeptId = model.DeptId;
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Privacy));
            }

            var employee = new Employee()
            {
                Name = model.Name,
                Address = model.Address,
                City = model.City,
                Phone = model.Phone,
                DeptId = model.DeptId
            };
            await db.AddAsync(employee);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Privacy));
        }

        [HttpGet]

        public async Task<IActionResult> EmployeeDelete(string id)
        {
            var emp = await db.Departments.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (emp is null)
            {
                return NotFound();
            }

            db.Remove(emp);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Privacy));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
