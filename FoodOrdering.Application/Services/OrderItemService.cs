using FoodOrdering.Application.DTOs;
using FoodOrdering.Application.Interfaces;
using FoodOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Application.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IApplicationDbContext _context;

        public OrderItemService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderItemDto>> GetAllOrderItemsAsync()
        {
            return await _context.OrderItem
                .Select(oi => new OrderItemDto
                {
                    OrderItemId = oi.OrderItemId,
                    OrderId = oi.OrderId.GetValueOrDefault(),
                    MenuItemId = oi.MenuItemId.GetValueOrDefault(),
                    Quantity = oi.Quantity,
                    ItemPrice = oi.Price
                })
                .ToListAsync();
        }

        public async Task<OrderItemDto?> GetOrderItemByIdAsync(int id)
        {
            var oi = await _context.OrderItem.FindAsync(id);
            if (oi == null) return null;

            return new OrderItemDto
            {
                OrderItemId = oi.OrderItemId,
                OrderId = oi.OrderId.GetValueOrDefault(),
                MenuItemId = oi.MenuItemId.GetValueOrDefault(),
                Quantity = oi.Quantity,
                ItemPrice = oi.Price
            };
        }

        public async Task<OrderItemDto> AddOrderItemAsync(CreateOrderItemDto dto)
        {
            var orderItem = new OrderItem
            {
                OrderId = dto.OrderId,
                MenuItemId = dto.MenuItemId,
                Quantity = dto.Quantity,
                Price = dto.ItemPrice
            };

            _context.OrderItem.Add(orderItem);
            await _context.SaveChangesAsync();

            return new OrderItemDto
            {
                OrderItemId = orderItem.OrderItemId,
                OrderId = orderItem.OrderId.GetValueOrDefault(),
                MenuItemId = orderItem.MenuItemId.GetValueOrDefault(),
                Quantity = orderItem.Quantity,
                ItemPrice = orderItem.Price
            };
        }

        public async Task<bool> UpdateOrderItemAsync(UpdateOrderItemDto dto)
        {
            var orderItem = await _context.OrderItem.FindAsync(dto.OrderItemId);
            if (orderItem == null) return false;

            orderItem.OrderId = dto.OrderId;
            orderItem.MenuItemId = dto.MenuItemId;
            orderItem.Quantity = dto.Quantity;
            orderItem.Price = dto.ItemPrice;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrderItemAsync(int id)
        {
            var entity = await _context.OrderItem.FindAsync(id);
            if (entity == null) return false;

            _context.OrderItem.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
