using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataAccess.Models;

public partial class Skill : BaseEntity
{
    public int Id { get; set; }

    public string? SkillName { get; set; }

    public virtual ICollection<CandidateSkill> CandidateSkills { get; set; } = new List<CandidateSkill>();

    public virtual ICollection<JobSkill> JobSkills { get; set; } = new List<JobSkill>();

}
