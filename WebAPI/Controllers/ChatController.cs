using DAL;
using DAL.Models;
using DAL.Models.DTO;
using DAL.Models.Helping;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private AppDbContext _context = new AppDbContext();


        [HttpPost("StartChat")]
        public IActionResult StartChat(ChatModel chat)
        {
            var entity = (from cht in _context.Chats.Where(x => x.Status == 1)
                          join prd in _context.Products.Where(x => x.Status == 1) on cht.ProductId equals prd.Id
                          join usr in _context.Users.Where(x => x.Status == 1) on prd.OwnerId equals usr.Id
                          where cht.ProductId == chat.ProductId
                          where cht.ApplierId == chat.ApplierId
                          select cht).FirstOrDefault();
            if (entity != null)
            {
                return Ok(chat.Id);
            }
            _context.Add(chat);
            _context.SaveChanges();
            return Ok(chat.Id);
        }

        [HttpPost("SendMessage")]
        public IActionResult SendMessage(MessageModel message)
        {
            _context.Add(message);
            _context.SaveChanges();
            return Ok(1);
        }


        [HttpGet("GetMessages")]
        public IActionResult GetMessages(int chatId, int userId)
        {
            List<MessageDTO> messages = (from chat in _context.Chats.Where(x => x.Status == 1 && x.Id == chatId)
                                         join msg in _context.Messages on chat.Id equals msg.ChatId
                                         join product in _context.Products.Where(x => x.Status != 0) on chat.ProductId equals product.Id
                                         select new MessageDTO
                                         {
                                             Message = msg.Message,
                                             ProductPrice = product.Price,
                                             ProductTitle = product.Name,
                                             IsLeft = (msg.SenderId == userId) ? false : true
                                         }).ToList();
            return Ok(messages);
        }

        [HttpGet("GetChats")]
        public IActionResult GetChats(int userId)
        {
            List<ChatDTO> chats = (from chat in _context.Chats.Where(x => x.Status == 1)
                                   join prd in _context.Products.Where(x => x.Status == 1) on chat.ProductId equals prd.Id
                                   join usr in _context.Users.Where(x => x.Status == 1) on (prd.OwnerId == userId) ? chat.ApplierId : prd.OwnerId equals usr.Id
                                   select new ChatDTO
                                   {
                                       Id = chat.Id,
                                       ToUser = usr.Name + " " + usr.SurName,
                                       UserOne = _context.Users.Where(x => x.Status == 1 && x.Id == prd.OwnerId).Select(x => x.Id).FirstOrDefault(),
                                       UserTwo = _context.Users.Where(x => x.Status == 1 && x.Id == chat.ApplierId).Select(y => y.Id).FirstOrDefault(),
                                   }).ToList();

            return Ok(chats.Where(x => x.UserOne == userId || x.UserTwo == userId));
        }

        [HttpGet("Deal")]
        public IActionResult Deal(int chatId)
        {
            try
            {
                ProductModel product = (from cht in _context.Chats.Where(x => x.Id == chatId && x.Status == 1)
                                        join prd in _context.Products.Where(x => x.Status == 1) on cht.ProductId equals prd.Id
                                        select prd).FirstOrDefault();
                product.Status = 2;
                _context.Products.Update(product);
                _context.SaveChanges();
                var entity = _context.Chats.Where(x => x.Status == 1 && x.Id == chatId).FirstOrDefault();
                entity.Status = 0;
                _context.Chats.Update(entity);
                _context.SaveChanges();

                return Ok(1);
            }
            catch (Exception ex)
            {
                return Ok(0);
            }

        }

        [HttpGet("GetChatOwner")]
        public IActionResult GetChatOwner(int chatId)
        {
            int owner = (from chat in _context.Chats.Where(x => x.Id == chatId && x.Status == 1)
                         join prd in _context.Products.Where(x => x.Status == 1) on chat.ProductId equals prd.Id
                         select prd.OwnerId).FirstOrDefault();
            return Ok(owner);
        }
    }
}
