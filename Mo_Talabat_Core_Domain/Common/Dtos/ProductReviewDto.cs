namespace Mo_Talabat_Core_Domain.Common.Dtos
{
    public class ProductReviewDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public bool IsVerified { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ReviewDate { get; set; }
    }

    public class CreateProductReviewDto
    {
        public int ProductId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
