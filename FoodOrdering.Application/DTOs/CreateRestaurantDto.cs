using System.ComponentModel.DataAnnotations;

public class CreateRestaurantDto
{
    [Required, StringLength(100)]
    public string RestaurantName { get; set; } = null!;

    [Required]
    public int CityId { get; set; }
}
