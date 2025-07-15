using System.ComponentModel.DataAnnotations;

public class UpdateCustomerDto
{
    [Required]
    public int CustomerId { get; set; }

    [Required, StringLength(100)]
    public string FullName { get; set; } = null!;

    [Phone, StringLength(20)]
    public string? Phone { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [StringLength(200)]
    public string? Address { get; set; }
}
