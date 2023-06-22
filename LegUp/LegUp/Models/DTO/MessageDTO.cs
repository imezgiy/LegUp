using System;
using System.Collections.Generic;
using System.Text;

namespace LegUp.Models.DTO
{
    public class MessageDTO
    {
        public string Message { get; set; }
        public bool IsLeft { get; set; }
        public string ProductTitle { get; set; }
        public int ProductPrice { get; set; }
    }
}
