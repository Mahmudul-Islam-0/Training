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
    public class DepartmentRepo : Repository<Department>, IDepartmentRepo
    {
        public DepartmentRepo(TrainingDBContext db) : base(db)
        {
        }

        public async Task AddAsync(Department model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            await db.Set<Department>().AddAsync(model);
        }

        public async Task<List<Department>> ToListAsync()
        {
            return await db.Set<Department>().ToListAsync();
        }

        public async Task<List<Department>> GetAllAsync() 
        {
            return await db.Set<Department>().ToListAsync();
        }

    }
}
