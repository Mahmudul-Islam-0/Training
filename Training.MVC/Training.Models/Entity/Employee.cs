using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Models.Entity
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string DeptId { get; set; } = string.Empty;

        public Department? Department { get; set; }
    }
}
