namespace FoodOrdering.Application.DTOs
{
    public class RestaurantDto
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; } = string.Empty;
        public int? CityId { get; set; }

    }
}
