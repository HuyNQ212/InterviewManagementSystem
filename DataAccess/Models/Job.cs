using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataAccess.Models;

public partial class Job : BaseEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal SalaryFrom { get; set; }

    public decimal SalaryTo { get; set; }

    public string? WorkingArea { get; set; }

    public string? Benefits { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<JobSkill> JobSkills { get; set; } = new List<JobSkill>();

}
