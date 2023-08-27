using System.Text.Json;

namespace DataAccess.Models;

public partial class InterviewerSchedule : BaseEntity
{
    public int Id { get; set; }

    public int InterviewId { get; set; }

    public int SheduleId { get; set; }

    public string? Note { get; set; }

    public virtual User Interview { get; set; } = null!;

    public virtual Schedule Shedule { get; set; } = null!;

}
