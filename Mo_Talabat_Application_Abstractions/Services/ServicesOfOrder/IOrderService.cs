using Mo_Talabat_Core_Domain.Common.Dtos;

namespace Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfOrder
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(int userId, CreateOrderDto createOrderDto);
        Task<OrderDto> GetOrderAsync(int orderId);
        Task<IEnumerable<OrderDto>> GetUserOrdersAsync(int userId);
        Task<OrderDto> UpdateOrderStatusAsync(int orderId, string status);
        Task<bool> CancelOrderAsync(int orderId);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    }
}
