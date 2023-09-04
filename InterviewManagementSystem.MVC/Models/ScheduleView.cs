using DataAccess.Models;

namespace InterviewManagementSystem.MVC.Models
{
    public class ScheduleView
    {
        public string? Title { get; set; }

        public DateTime? InterviewTimeStart { get; set; }

        public DateTime? InterviewTimeEnd { get; set; }

        public string? Location { get; set; }

        public string? MeetingId { get; set; }

        public string? Note { get; set; }

        public string? Result { get; set; }

        public virtual ICollection<InterviewerSchedule> InterviewerSchedules { get; set; } = new List<InterviewerSchedule>();
    }
}
