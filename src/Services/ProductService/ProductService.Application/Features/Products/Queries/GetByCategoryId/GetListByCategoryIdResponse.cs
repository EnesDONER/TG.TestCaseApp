﻿namespace ProductService.Application.Features.Products.Queries.GetByCategoryId;

public class GetListByCategoryIdResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
