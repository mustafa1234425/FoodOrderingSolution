
namespace FoodOrdering.Application.DTOs
{
    public class MenuItemDto
    {
        public int MenuItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
