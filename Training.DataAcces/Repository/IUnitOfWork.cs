using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DataAcces.Repository.Interface;

namespace Training.DataAcces.Repository
{
    public interface IUnitOfWork
    {
        public IDepartmentRepo DepartmentRepo { get; }

        public IEmployeeRepo EmployeeRepo { get; }

        public IDesignationRepo DesignationRepo { get; }
        Task Save();
    }
}
