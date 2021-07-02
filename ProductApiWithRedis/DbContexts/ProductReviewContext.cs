using Microsoft.EntityFrameworkCore;
using ProductApiWithRedis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApiWithRedis.DbContexts
{
    public class ProductReviewContext : DbContext
    {
        public ProductReviewContext(DbContextOptions<ProductReviewContext> options) : base(options)
        {
        }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
