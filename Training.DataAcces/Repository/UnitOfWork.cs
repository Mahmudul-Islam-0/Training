using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DataAcces.Repository.Implement;
using Training.DataAcces.Repository.Interface;

namespace Training.DataAcces.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TrainingDBContext db;

        public IDepartmentRepo DepartmentRepo { get; private set; }

        public IEmployeeRepo EmployeeRepo { get; private set; }

        public IDesignationRepo DesignationRepo { get; private set; }
        public UnitOfWork(TrainingDBContext db)
        {
            DepartmentRepo = new DepartmentRepo(db);
            EmployeeRepo = new EmployeeRepo(db);   
            DesignationRepo = new DesignationRepo(db); 
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }
    }
}
