using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DataAcces.Repository.Interface;
using Training.Models.Entity;

namespace Training.DataAcces.Repository.Implement
{
    public class EmployeeRepo : Repository<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(TrainingDBContext db) : base(db)
        {
        }

        public async Task AddAsync(Employee model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            await db.Set<Employee>().AddAsync(model);
        }
        public async Task<List<Employee>> GetIncludedept()
        {
           return await db.Employees.Include(d => d.Department).ToListAsync();
        }
        public async Task<List<Employee>> GetAllAsync() 
        {
            return await db.Set<Employee>().ToListAsync();
        }

    }
}
