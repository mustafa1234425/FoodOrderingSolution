using System.ComponentModel.DataAnnotations;

public class UpdateRestaurantDto
{
    [Required]
    public int RestaurantId { get; set; }

    [Required, StringLength(100)]
    public string RestaurantName { get; set; } = null!;

    [Required]
    public int CityId { get; set; }
}
