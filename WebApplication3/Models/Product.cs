using System;
using System.Collections.Generic;

namespace WebApplication3.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Title { get; set; } = null!;

    public string Category { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
