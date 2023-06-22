using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string OwnerName { get; set; }
        public string Detail { get; set; }
        public string ColorCode { get; set; }
        public string Type { get; set; }
        public string University { get; set; }
        public bool IsVisible { get; set; }

        public string Description { get; set; }
    }
}
