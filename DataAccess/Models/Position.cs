using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataAccess.Models;

public partial class Position : BaseEntity
{
    public int Id { get; set; }

    public string? PositionName { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

}
