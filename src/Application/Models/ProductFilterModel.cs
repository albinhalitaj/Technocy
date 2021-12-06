using System.Collections.Generic;

namespace Application.Models
{
    public class ProductFilterModel
    {
        public decimal StartingPrice { get; set; }
        public decimal EndingPrice { get; set; }
        public bool Visibility { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}