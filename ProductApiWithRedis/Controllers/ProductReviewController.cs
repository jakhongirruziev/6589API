using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using ProductApiWithRedis.Model;
using ProductApiWithRedis.Repositories;
using ProductApiWithRedis.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApiWithRedis.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductReview")]
    public class ProductReviewController : ControllerBase
    {
        private readonly IProductReviewRepository _productReviewRepository;
        
        public ProductReviewController(IProductReviewRepository productReviewRepository)
        {
            _productReviewRepository = productReviewRepository;
        }

        // GET: api/ProductReview
        [HttpGet]
        public IActionResult Get()
        {
            var productReviews = _productReviewRepository.GetProductReviews();
            return new OkObjectResult(productReviews);
            //return new string[] { "value1", "value2" };
        }

        // GET api/ProductReview/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var productReview = _productReviewRepository.GetProductReviewById(id);
            return new OkObjectResult(productReview);
            //return "value";
        }

        // POST: api/ProductReview
        [HttpPost]
        public IActionResult Post([FromBody] ProductReview productReview)
        {
            using (var scope = new TransactionScope())
            {
                _productReviewRepository.InsertProductReview(productReview);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = productReview.Id }, productReview);
            }
        }

        // PUT: api/ProductReview/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductReview productReview)
        {
            if (productReview != null)
            {
                using (var scope = new TransactionScope())
                {
                    _productReviewRepository.UpdateProductReview(productReview);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ProductReview/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productReviewRepository.DeleteProductReview(id);
            return new OkResult();
        }
    }
}