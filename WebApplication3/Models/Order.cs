using System;
using System.Collections.Generic;

namespace WebApplication3.Models;
public class OrderViewModel
{
    public int OrderId { get; set; }
    public string Status { get; set; }
    public string Username { get; set; }
    public string Payment { get; set; }
    public int Quantity { get; set; }
}
public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public string Payment { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
