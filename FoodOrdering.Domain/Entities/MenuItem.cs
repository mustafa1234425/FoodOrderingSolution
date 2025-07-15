using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FoodOrdering.Domain.Entities;

public partial class MenuItem
{
    [Key]
    public int MenuItemId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(300)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [StringLength(300)]
    public string? ImageUrl { get; set; }

    public int? RestaurantId { get; set; }

    [InverseProperty("MenuItem")]
    public virtual ICollection<OrderItem> OrderItem { get; set; } = new List<OrderItem>();

    [ForeignKey("RestaurantId")]
    [InverseProperty("MenuItem")]
    public virtual Restaurant? Restaurant { get; set; }
}
