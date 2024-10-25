using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Models.Entity;

namespace Training.DataAcces
{
    public class TrainingDBContext : DbContext
    {
        public TrainingDBContext(DbContextOptions <TrainingDBContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }

    }
}
