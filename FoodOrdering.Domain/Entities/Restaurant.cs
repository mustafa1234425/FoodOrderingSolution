using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FoodOrdering.Domain.Entities;

public partial class Restaurant
{
    [Key]
    public int RestaurantId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    [StringLength(300)]
    public string? ImageUrl { get; set; }

    public int? CityId { get; set; }

    [ForeignKey("CityId")]
    [InverseProperty("Restaurant")]
    public virtual City? City { get; set; }

    [InverseProperty("Restaurant")]
    public virtual ICollection<MenuItem> MenuItem { get; set; } = new List<MenuItem>();
}
