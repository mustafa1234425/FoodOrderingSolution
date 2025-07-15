using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Application.DTOs;

public class CreateCustomerDto
{
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = null!;

    [MaxLength(20)]
    public string? Phone { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [MaxLength(200)]
    public string? Address { get; set; }
}
