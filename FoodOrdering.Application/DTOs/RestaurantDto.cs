namespace FoodOrdering.Application.DTOs
{
    public class RestaurantDto
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; } = string.Empty;
        public required string Description { get; set; }
        public int? CityId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

    }
}
