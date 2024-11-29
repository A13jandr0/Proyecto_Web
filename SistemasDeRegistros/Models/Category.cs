using System;
using System.Collections.Generic;

namespace SistemasDeRegistros.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
