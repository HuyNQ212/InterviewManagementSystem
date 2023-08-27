using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataAccess.Models;

public partial class User : BaseEntity
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Status { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int RoleId { get; set; }

    public int DepartmentId { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<InterviewerSchedule> InterviewerSchedules { get; set; } = new List<InterviewerSchedule>();

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual Role Role { get; set; } = null!;

}
