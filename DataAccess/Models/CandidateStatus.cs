using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataAccess.Models;

public partial class CandidateStatus : BaseEntity
{
    public int Id { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

}
