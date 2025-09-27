using Microsoft.AspNetCore.Mvc;
using Share;
using Share.Services;
using Mo_Talabat_Core_Domain.Common.Dtos;

namespace Mo_Api_Talabat_Controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController(IServiceManager serviceManager) : BaseApiController
    {
        [HttpGet("{reviewId:int}")]
        public async Task<ActionResult<ProductReviewDto>> GetReview(int reviewId)
        {
            var review = await serviceManager.ReviewService.GetReviewAsync(reviewId);
            return Ok(review);
        }

        [HttpGet("product/{productId:int}")]
        public async Task<ActionResult<IEnumerable<ProductReviewDto>>> GetProductReviews(int productId)
        {
            var reviews = await serviceManager.ReviewService.GetProductReviewsAsync(productId);
            return Ok(reviews);
        }

        [HttpGet("user/{userId:int}")]
        public async Task<ActionResult<IEnumerable<ProductReviewDto>>> GetUserReviews(int userId)
        {
            var reviews = await serviceManager.ReviewService.GetUserReviewsAsync(userId);
            return Ok(reviews);
        }

        [HttpPost("{userId:int}")]
        public async Task<ActionResult<ProductReviewDto>> CreateReview(int userId, [FromBody] CreateProductReviewDto createReviewDto)
        {
            var review = await serviceManager.ReviewService.CreateReviewAsync(userId, createReviewDto);
            return Ok(review);
        }

        [HttpPut("{reviewId:int}")]
        public async Task<ActionResult<ProductReviewDto>> UpdateReview(int reviewId, [FromBody] CreateProductReviewDto updateReviewDto)
        {
            var review = await serviceManager.ReviewService.UpdateReviewAsync(reviewId, updateReviewDto);
            return Ok(review);
        }

        [HttpDelete("{reviewId:int}")]
        public async Task<ActionResult> DeleteReview(int reviewId)
        {
            var result = await serviceManager.ReviewService.DeleteReviewAsync(reviewId);
            return result ? Ok() : NotFound();
        }

        [HttpPut("{reviewId:int}/approve")]
        public async Task<ActionResult> ApproveReview(int reviewId)
        {
            var result = await serviceManager.ReviewService.ApproveReviewAsync(reviewId);
            return result ? Ok() : NotFound();
        }

        [HttpPut("{reviewId:int}/reject")]
        public async Task<ActionResult> RejectReview(int reviewId)
        {
            var result = await serviceManager.ReviewService.RejectReviewAsync(reviewId);
            return result ? Ok() : NotFound();
        }

        [HttpGet("product/{productId:int}/rating")]
        public async Task<ActionResult<decimal>> GetProductAverageRating(int productId)
        {
            var rating = await serviceManager.ReviewService.GetProductAverageRatingAsync(productId);
            return Ok(rating);
        }

        [HttpGet("product/{productId:int}/count")]
        public async Task<ActionResult<int>> GetProductReviewsCount(int productId)
        {
            var count = await serviceManager.ReviewService.GetProductReviewsCountAsync(productId);
            return Ok(count);
        }
    }
}
