using System;
using System.Collections.Generic;
using System.Text;

namespace LegUp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int Price { get; set; }
        public int OwnerId { get; set; }
        public int HelpTypeId { get; set; }
        public int UniversityId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }

    }
}
