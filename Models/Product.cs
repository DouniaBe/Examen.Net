using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Net.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Navigatie-eigenschappen
        public List<Order> Orders { get; set; } = new List<Order>();
        public override string ToString()
        {
            return $"{Name} - {Price:C}";
        }
    }
}
