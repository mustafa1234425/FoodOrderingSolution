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
                    CustomerId = o.CustomerId ?? 0,
                    OrderDate = o.OrderDate ?? DateTime.Now,
                    TotalPrice = o.TotalPrice
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
                TotalPrice = order.TotalPrice
            };
        }

        public async Task<OrderDto> AddOrderAsync(CreateOrderDto dto)
        {
            Customer customer;

            // Check if customer already exists by email or phone
            customer = await _context.Customer.FirstOrDefaultAsync(x =>
                x.Email == dto.Customer.Email || x.Phone == dto.Customer.Phone);

            if (customer == null)
            {
                // Create new customer since none exists
                customer = new Customer
                {
                    FullName = dto.Customer.FullName,
                    Phone = dto.Customer.Phone,
                    Email = dto.Customer.Email,
                    Address = dto.Customer.Address
                };

                _context.Customer.Add(customer);
                await _context.SaveChangesAsync();
            }

            // Create order with the customer ID (either existing or newly created)
            var order = new Order
            {
                CustomerId = customer.CustomerId,
                OrderDate = DateTime.Now,
                TotalPrice = dto.TotalPrice
            };

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return new OrderDto
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId ?? 0,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice
            };
        }

        public async Task<bool> UpdateOrderAsync(UpdateOrderDto dto)
        {
            var order = await _context.Order.FindAsync(dto.OrderId);
            if (order == null) return false;

            order.CustomerId = dto.CustomerId;
            order.OrderDate = dto.OrderDate ?? DateTime.Now;
            order.TotalPrice = dto.TotalPrice;

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