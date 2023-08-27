using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataAccess.Models;

public partial class Department : BaseEntity
{
    public int Id { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

}
