namespace FoodOrdering.Application.DTOs
{
    public class CreateOrderDto
    {
        public CustomerDto Customer { get; set; } = null!;
        public int RestaurantId { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
        public decimal TotalPrice { get; set; }
    }
}
