using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DataAcces.Repository.Interface;
using Training.Models.Entity;

namespace Training.DataAcces.Repository.Implement
{
    public class DesignationRepo : Repository<Designation>, IDesignationRepo
    {
        public DesignationRepo(TrainingDBContext db) : base(db)
        {
        }
    }
}
