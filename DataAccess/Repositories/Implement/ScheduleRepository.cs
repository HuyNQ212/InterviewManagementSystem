using DataAccess.Models;

namespace DataAccess.Repositories.Implement
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(InterviewManagementContext context) : base(context)
        {
        }
    }
}
