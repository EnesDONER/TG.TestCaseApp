﻿using Core.Persistence.Repositories;

namespace ProductService.Domain;

public class Product: Entity<Guid>
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Category Category { get; set; }

    private Product()
    {
        
    }

    public Product(Guid id, Guid categoryId, string name, decimal price):this()
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        Price = price;
    }
}