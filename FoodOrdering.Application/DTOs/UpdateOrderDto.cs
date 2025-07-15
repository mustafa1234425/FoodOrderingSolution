using System.ComponentModel.DataAnnotations;

public class UpdateOrderDto
{
    [Required]
    public int OrderId { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal TotalAmount { get; set; }
}
