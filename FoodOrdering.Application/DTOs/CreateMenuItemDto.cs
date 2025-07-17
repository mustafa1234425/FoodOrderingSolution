using System.ComponentModel.DataAnnotations;

public class CreateMenuItemDto
{
    [Required, StringLength(100)]
    public string ItemName { get; set; } = null!;

    [StringLength(300)]
    public string? Description { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    public int RestaurantId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}
