using DataAccess.Models;

namespace DataAccess.Repositories.Implement
{
    public class InterviewScheduleRepository : BaseRepository<InterviewerSchedule>, IInterviewScheduleRepository
    {
        public InterviewScheduleRepository(InterviewManagementContext context) : base(context)
        {
        }
    }
}
