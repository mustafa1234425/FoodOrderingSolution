using System.ComponentModel.DataAnnotations;

public class CreateRestaurantDto
{
    [Required, StringLength(100)]
    public string RestaurantName { get; set; } = null!;

    public required string Description { get; set; }

    [Required]
    public int CityId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;

}
