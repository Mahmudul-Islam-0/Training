﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Models.Entity;

namespace Training.Models.DTO
{
    public class EmpListDTO
    {
        public  string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string DeptId { get; set; } = string.Empty;


    }
}
