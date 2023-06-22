using DAL;
using DAL.Models.DTO;
using DAL.Models.Helping;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpingController : ControllerBase
    {
        private AppDbContext _context = new AppDbContext();

        [HttpGet("GetProductsByOwner")]
        public IActionResult GetProducts(int userId)
        {
            List<ProductDTO> products = (from product in _context.Products.Where(x => x.OwnerId == userId && x.Status != 0)
                                         join user in _context.Users.Where(x => x.Status == 1) on product.OwnerId equals user.Id
                                         join type in _context.HelpTypes on product.HelpTypeId equals type.Id
                                         join uni in _context.Universities on product.UniversityId equals uni.Id
                                         select new ProductDTO
                                         {
                                             Id= product.Id,
                                             OwnerName = user.Name + " " + user.SurName,
                                             Price = product.Price,
                                             Title = product.Name,
                                             Detail = product.Detail,
                                             Type = type.Title,
                                             University = uni.Title,
                                             ColorCode = product.Status == 2 ? "rgb(206, 229, 208)" : _context.Chats.Where(x => x.ProductId == product.Id).Any() ? "rgb(252, 248, 232)" : "rgb(236, 179, 144)",
                                             IsVisible = false
                                             
                                         }).ToList();
            return Ok(products);
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts(int userId)
        {
            List<ProductDTO> products = (from product in _context.Products.Where(x=> x.Status != 0 && x.OwnerId != userId)
                                         join user in _context.Users.Where(x => x.Status == 1) on product.OwnerId equals user.Id
                                         join type in _context.HelpTypes on product.HelpTypeId equals type.Id
                                         join uni in _context.Universities on product.UniversityId equals uni.Id
                                         select new ProductDTO
                                         {
                                             Id = product.Id,
                                             OwnerName = user.Name + " " + user.SurName,
                                             Price = product.Price,
                                             Title = product.Name,
                                             Detail = product.Detail,
                                             Type = type.Title,
                                             University = uni.Title,
                                             ColorCode = product.Status == 2 ? "rgb(206, 229, 208)" : _context.Chats.Where(x => x.ProductId == product.Id).Any() ? "rgb(252, 248, 232)" : "rgb(236, 179, 144)",
                                             IsVisible = product.Status == 2 ? false : true,
                                             Description = product.Status == 2 ? "Anlaşma Yapılmış" : _context.Chats.Where(x => x.ProductId == product.Id).Any() ? "Görüşme Aşamasında" : "Yardım Bekliyor"

                                         }).ToList();
            return Ok(products);
        }


        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct(ProductModel product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return Ok(1);
        }

        [HttpGet("GetUniversities")]
        public IActionResult GetUniversities()
        {
            return Ok(_context.Universities.ToList());
        }
        [HttpGet("GetTypes")]
        public IActionResult GetTypes()
        {
            return Ok(_context.HelpTypes.ToList());
        }

    }
}
