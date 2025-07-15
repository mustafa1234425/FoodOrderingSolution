using FoodOrdering.Application.DTOs;

namespace FoodOrdering.Application.Interfaces
{
    public interface IOrderItemService
    {
        Task<List<OrderItemDto>> GetAllOrderItemsAsync();
        Task<OrderItemDto?> GetOrderItemByIdAsync(int id);
        Task<OrderItemDto> AddOrderItemAsync(CreateOrderItemDto dto);
        Task<bool> UpdateOrderItemAsync(UpdateOrderItemDto dto);
        Task<bool> DeleteOrderItemAsync(int id);
    }
}
