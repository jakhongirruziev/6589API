using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApiWithRedis.Model
{
    public class ProductReview
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Review { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
