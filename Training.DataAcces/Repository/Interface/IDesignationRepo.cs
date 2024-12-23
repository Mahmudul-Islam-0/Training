﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Models.Entity;

namespace Training.DataAcces.Repository.Interface
{
    public interface IDesignationRepo : IRepository<Designation>
    {
        Task AddAsync(Designation designation);
    }

}
