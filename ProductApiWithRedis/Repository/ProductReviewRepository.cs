using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProductApiWithRedis.DbContexts;
using ProductApiWithRedis.Model;
using ProductApiWithRedis.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApiWithRedis.Repositories
{
    public class ProductReviewRepository : IProductReviewRepository
    {
        private readonly ProductReviewContext _dbContext;

        public ProductReviewRepository(ProductReviewContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteProductReview(int productReviewId)
        {
            var productReview = _dbContext.ProductReviews.Find(productReviewId);
            _dbContext.ProductReviews.Remove(productReview);
            Save();
        }

        public ProductReview GetProductReviewById(int productReviewId)
        {
            var review = _dbContext.ProductReviews.Find(productReviewId);
            _dbContext.Entry(review).Reference(s => s.Product).Load();
            return review;
        }

        public IEnumerable<ProductReview> GetProductReviews()
        {
            return _dbContext.ProductReviews.Include(s => s.Product).ToList();
        }

        public void InsertProductReview(ProductReview productReview)
        {
            _dbContext.Add(productReview);
            Save();
        }

        public void UpdateProductReview(ProductReview productReview)
        {
            _dbContext.Entry(productReview).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
