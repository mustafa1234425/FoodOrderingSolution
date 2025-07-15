using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FoodOrdering.Domain.Entities;

public partial class OrderItem
{
    [Key]
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? MenuItemId { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [StringLength(300)]
    public string? ImageUrl { get; set; }

    [ForeignKey("MenuItemId")]
    [InverseProperty("OrderItem")]
    public virtual MenuItem? MenuItem { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItem")]
    public virtual Order? Order { get; set; }
}
