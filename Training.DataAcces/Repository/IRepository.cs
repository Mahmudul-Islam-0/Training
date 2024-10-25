using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.DataAcces.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T model);
        void Edit(T model);
        void Delete(T model);

        Task<List<T>> GetAll();

        Task<T> GetById(object id);

        Task Save();
    }
}
