using System.ComponentModel.DataAnnotations;

public class UpdateRestaurantDto
{
    [Required]
    public int RestaurantId { get; set; }

    [Required, StringLength(100)]
    public string RestaurantName { get; set; } = null!;

    public required string Description { get; set; }

    [Required]
    public int CityId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;

}
