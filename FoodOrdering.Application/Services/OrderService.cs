using FoodOrdering.Application.DTOs;
using FoodOrdering.Application.Interfaces;
using FoodOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IApplicationDbContext _context;

        public OrderService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            return await _context.Order
                .Select(o => new OrderDto
                {
                    OrderId = o.OrderId,
                    CustomerId = o.CustomerId ?? 0, // استخدم 0 كقيمة افتراضية أو حسب منطق التطبيق
                    OrderDate = o.OrderDate ?? DateTime.Now,
                    TotalAmount = o.TotalPrice
                })
                .ToListAsync();
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null) return null;

            return new OrderDto
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId ?? 0,
                OrderDate = order.OrderDate ?? DateTime.Now,
                TotalAmount = order.TotalPrice
            };
        }

        public async Task<OrderDto> AddOrderAsync(CreateOrderDto dto)
        {
            var order = new Order
            {
                CustomerId = dto.CustomerId,
                OrderDate = dto.OrderDate,
                TotalPrice = dto.TotalAmount
            };

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return new OrderDto
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId ?? 0,
                OrderDate = order.OrderDate ?? DateTime.Now,
                TotalAmount = order.TotalPrice
            };
        }

        public async Task<bool> UpdateOrderAsync(UpdateOrderDto dto)
        {
            var order = await _context.Order.FindAsync(dto.OrderId);
            if (order == null) return false;

            order.CustomerId = dto.CustomerId;
            order.OrderDate = dto.OrderDate;
            order.TotalPrice = dto.TotalAmount;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var entity = await _context.Order.FindAsync(id);
            if (entity == null) return false;

            _context.Order.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
