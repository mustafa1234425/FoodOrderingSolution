using System.ComponentModel.DataAnnotations;

public class UpdateOrderItemDto
{
    [Required]
    public int OrderItemId { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public int MenuItemId { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal ItemPrice { get; set; }
}
