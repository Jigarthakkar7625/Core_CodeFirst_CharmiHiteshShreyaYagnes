using System;
using System.Collections.Generic;

namespace Core_CodeFirst.Data.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;
}
