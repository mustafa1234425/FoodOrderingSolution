using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FoodOrdering.Domain.Entities;

public partial class City
{
    [Key]
    public int CityId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("City")]
    public virtual ICollection<Restaurant> Restaurant { get; set; } = new List<Restaurant>();
}
