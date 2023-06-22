using System;
using System.Collections.Generic;
using System.Text;

namespace LegUp.Models
{
    public class ChatModel
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int ApplierId { get; set; }
        public int ProductId { get; set; }
    }
}
