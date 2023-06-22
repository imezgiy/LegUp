using System;
using System.Collections.Generic;
using System.Text;

namespace LegUp.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public string Message { get; set; }
        public int SenderId { get; set; }
    }
}
