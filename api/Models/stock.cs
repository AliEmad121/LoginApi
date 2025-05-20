using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
