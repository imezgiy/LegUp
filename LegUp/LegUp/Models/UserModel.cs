using System;
using System.Collections.Generic;
using System.Text;

namespace LegUp.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string State { get; set; }

        public string University { get; set; }

        public string Department { get; set; }

        public int Gender { get; set; }
        public int HelpScore { get; set; }
        public int RoleId { get; set; }


        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
    }
}


