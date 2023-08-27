using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataAccess.Models;

public partial class Role : BaseEntity
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();

}
