using LegUp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegUp.StaticClasses
{
    public class UserConfig
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static string Surname { get; set; }
        public static string Email { get; set; }
        public static string University { get; set; }
        public static string Department { get; set; }
        public static string Gender { get; set; }
        public static int HelpScore { get; set; }
        public static int SelectedChat { get; set; }

        public static void SetConfig(UserModel user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.SurName;
            Email = user.Email;
            University = user.University;
            Department = user.Department;
            Gender = user.Gender == 1? "Erkek" : "Kadın";
            HelpScore = user.HelpScore;
            SelectedChat = 0;
        }
    }
}
