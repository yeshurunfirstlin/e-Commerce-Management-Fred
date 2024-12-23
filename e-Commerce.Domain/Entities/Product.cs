﻿namespace e_Commerce.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

    public Category? Category { get; set; } // navigation property
    public int CategoryId { get; set; }
}