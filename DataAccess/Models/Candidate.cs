using System.ComponentModel;

namespace DataAccess.Models;

public partial class Candidate : BaseEntity
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public string? Cvattachment { get; set; }

    public int? StatusId { get; set; }

    public int? YearOfExperience { get; set; }

    public int? RecruiterId { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<CandidateSkill> CandidateSkills { get; set; } = new List<CandidateSkill>();

    public virtual User? Recruiter { get; set; }

    public virtual CandidateStatus? Status { get; set; }

    public virtual Offer? Offer { get; set; }

    public virtual Schedule? Schedule { get; set; }

}
