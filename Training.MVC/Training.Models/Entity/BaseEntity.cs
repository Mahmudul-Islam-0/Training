using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Models.Entity
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsDeleted { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
