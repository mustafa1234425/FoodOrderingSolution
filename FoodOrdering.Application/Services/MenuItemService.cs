using FoodOrdering.Application.DTOs;
using FoodOrdering.Application.Interfaces;
using FoodOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.Application.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IApplicationDbContext _context;

        public MenuItemService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuItemDto>> GetAllMenuItemsAsync()
        {
            return await _context.MenuItem
                .Select(m => new MenuItemDto
                {
                    MenuItemId = m.MenuItemId,
                    ItemName = m.Name,
                    Description = m.Description,
                    Price = m.Price,
                    RestaurantId = m.RestaurantId ?? 0,
                    ImageUrl = m.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<MenuItemDto?> GetMenuItemByIdAsync(int id)
        {
            var item = await _context.MenuItem.FindAsync(id);
            if (item == null) return null;

            return new MenuItemDto
            {
                MenuItemId = item.MenuItemId,
                ItemName = item.Name,
                Description = item.Description,
                Price = item.Price,
                RestaurantId = item.RestaurantId ?? 0,
                ImageUrl = item.ImageUrl
            };
        }

        public async Task<MenuItemDto> AddMenuItemAsync(CreateMenuItemDto dto)
        {
            var menuItem = new MenuItem
            {
                Name = dto.ItemName,
                Description = dto.Description,
                Price = dto.Price,
                RestaurantId = dto.RestaurantId,
                ImageUrl = dto.ImageUrl
            };

            _context.MenuItem.Add(menuItem);
            await _context.SaveChangesAsync();

            return new MenuItemDto
            {
                MenuItemId = menuItem.MenuItemId,
                ItemName = menuItem.Name,
                Description = menuItem.Description,
                Price = menuItem.Price,
                RestaurantId = menuItem.RestaurantId ?? 0,
                ImageUrl= menuItem.ImageUrl
            };
        }

        public async Task<bool> UpdateMenuItemAsync(UpdateMenuItemDto dto)
        {
            var menuItem = await _context.MenuItem.FindAsync(dto.MenuItemId);
            if (menuItem == null) return false;

            menuItem.Name = dto.ItemName;
            menuItem.Description = dto.Description;
            menuItem.Price = dto.Price;
            menuItem.RestaurantId = dto.RestaurantId;
            menuItem.ImageUrl = dto.ImageUrl;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            var entity = await _context.MenuItem.FindAsync(id);
            if (entity == null) return false;

            _context.MenuItem.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<MenuItemDto>> GetByRestaurantIdAsync(int restaurantId)
        {
            return await _context.MenuItem
                .Where(m => m.RestaurantId == restaurantId)
                .Select(m => new MenuItemDto
                {
                    MenuItemId = m.MenuItemId,
                    ItemName = m.Name,
                    Description = m.Description,
                    Price = m.Price,
                    RestaurantId = m.RestaurantId?? 0,
                    ImageUrl = m.ImageUrl
                })
                .ToListAsync();
        }
    }
}
