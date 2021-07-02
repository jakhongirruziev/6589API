using ProductApiWithRedis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApiWithRedis.Repository
{
    public interface IProductReviewRepository
    {
        void InsertProductReview(ProductReview productReview);
        void UpdateProductReview(ProductReview productReview);
        void DeleteProductReview(int productReviewId);
        ProductReview GetProductReviewById(int id);
        IEnumerable<ProductReview> GetProductReviews();
    }
}
