using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataAccess.Models;

public partial class JobSkill : BaseEntity
{
    public int Id { get; set; }

    public int JobId { get; set; }

    public int SkillId { get; set; }

    public bool IsMustHave { get; set; }

    public virtual Job Job { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;

}
