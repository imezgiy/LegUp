using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string SurName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(30)]
        public string State { get; set; }
        [StringLength(150)]
        public string University { get; set; }
        [StringLength(100)]
        public string Department { get; set; }
     
        public int Gender { get; set; }
        public int HelpScore { get; set; }
        public int RoleId { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(20)]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
    }
}
