using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace DataAccess.Models;

public partial class Candidate : BaseEntity
{
    public int Id { get; set; }

    [DisplayName("Full name")]
    public string FullName { get; set; } = null!;

    [DisplayName("Date Of Birth")]
    public DateTime DateOfBirth { get; set; }

    [DisplayName("Phone number")]
    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Address { get; set; }

    public string? Gender { get; set; }

    [DisplayName("CV Attachment")]
    public string? Cvattachment { get; set; }

    public int? StatusId { get; set; }

    [DisplayName("Year of experiences")]
    public int? YearOfExperience { get; set; }

    public int? RecruiterId { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<CandidateSkill> CandidateSkills { get; set; } = new List<CandidateSkill>();

    public virtual User? Recruiter { get; set; }

    public virtual CandidateStatus? Status { get; set; }

}
