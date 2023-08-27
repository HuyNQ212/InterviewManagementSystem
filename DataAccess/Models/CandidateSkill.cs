using System.Text.Json;

namespace DataAccess.Models;

public partial class CandidateSkill : BaseEntity
{
    public int Id { get; set; }

    public int CandidateId { get; set; }

    public int SkillId { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;


}
