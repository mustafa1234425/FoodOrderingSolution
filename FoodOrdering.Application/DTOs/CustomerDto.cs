﻿namespace FoodOrdering.Application.DTOs;

public class CustomerDto
{
    public int CustomerId { get; set; }
    public string FullName { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}
