using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        public readonly AppDbContext _context = new AppDbContext();

        [HttpGet("LoginCheck")]
        public UserModel LoginCheck(string UserName, string Password)
        {

            UserModel user = _context.Users.Where(x => x.UserName == UserName && x.Password == Password&&x.Status==1).FirstOrDefault();

            return user;

        }


        [HttpPost("CreateUser")]
        public int CreateUser(UserModel model)
        {
            UserModel myuser = _context.Users.Where(x => x.Email == model.Email).FirstOrDefault();
            if(myuser == null)
            {
                model.CreatedDate = DateTime.Now;
                model.Status = 1;
                model.HelpScore = 30;
                _context.Users.Add(model);
            }
           
           
            _context.SaveChanges();
            return 1;

        }



    }
}
