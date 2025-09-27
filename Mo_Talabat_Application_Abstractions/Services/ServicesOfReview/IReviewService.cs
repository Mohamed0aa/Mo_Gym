using Mo_Talabat_Core_Domain.Common.Dtos;

namespace Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfReview
{
    public interface IReviewService
    {
        Task<ProductReviewDto> GetReviewAsync(int reviewId);
        Task<IEnumerable<ProductReviewDto>> GetProductReviewsAsync(int productId);
        Task<IEnumerable<ProductReviewDto>> GetUserReviewsAsync(int userId);
        Task<ProductReviewDto> CreateReviewAsync(int userId, CreateProductReviewDto createReviewDto);
        Task<ProductReviewDto> UpdateReviewAsync(int reviewId, CreateProductReviewDto updateReviewDto);
        Task<bool> DeleteReviewAsync(int reviewId);
        Task<bool> ApproveReviewAsync(int reviewId);
        Task<bool> RejectReviewAsync(int reviewId);
        Task<decimal> GetProductAverageRatingAsync(int productId);
        Task<int> GetProductReviewsCountAsync(int productId);
    }
}
