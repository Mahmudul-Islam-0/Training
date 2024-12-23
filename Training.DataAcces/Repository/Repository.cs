﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.DataAcces.Repository 
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TrainingDBContext db;

        public Repository(TrainingDBContext db)
        {
            this.db = db;

        }
        public void Add(T model)
        {
            db.Set<T>().Add(model);
        }

        public void Delete(T model)
        {
            db.Set<T>().Remove(model);
        }

        public void Edit(T model)
        {
            db.Set<T>().Attach(model);
            db.Entry(model).State = EntityState.Modified;
        }

        public async Task<List<T>> GetAll()
        {
            return await db.Set<T>().ToListAsync();

        }

        public async Task<T> GetById(string id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        //public async Task<T> GetById(object id) => await db.Set<T>().FindAsync(id);


        public async Task Save()
        {
            await db.SaveChangesAsync();
        }
    }
}
