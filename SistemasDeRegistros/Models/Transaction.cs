using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int CategoryId { get; set; }

    public int Amount { get; set; }

    public string? Note { get; set; }

    public DateTime Date { get; set; }

    public virtual Category Category { get; set; } = null!;
}
