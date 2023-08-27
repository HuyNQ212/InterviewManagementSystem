using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataAccess.Models;

public partial class Schedule : BaseEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime? InterviewTimeStart { get; set; }

    public DateTime? InterviewTimeEnd { get; set; }

    public string? Location { get; set; }

    public string? MeetingId { get; set; }

    public string? Note { get; set; }

    public string? Result { get; set; }

    public virtual ICollection<InterviewerSchedule> InterviewerSchedules { get; set; } = new List<InterviewerSchedule>();

}
