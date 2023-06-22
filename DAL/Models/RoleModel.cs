using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
    }
}
