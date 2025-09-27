using Mo_Talabat_Core_Domain.Common.Dtos;

namespace Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfCart
{
    public interface ICartService
    {
        Task<CartDto> GetCartAsync(int userId);
        Task<CartItemDto> AddToCartAsync(int userId, int productId, int quantity = 1);
        Task<CartItemDto> UpdateCartItemAsync(int userId, int productId, int quantity);
        Task<bool> RemoveFromCartAsync(int userId, int productId);
        Task<bool> ClearCartAsync(int userId);
        Task<int> GetCartItemsCountAsync(int userId);
    }
}
