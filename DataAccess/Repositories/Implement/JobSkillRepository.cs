using DataAccess.Models;

namespace DataAccess.Repositories.Implement
{
    public class JobSkillRepository : BaseRepository<JobSkill>, IJobSkillRepository
    {
        public JobSkillRepository(InterviewManagementContext context) : base(context)
        {
        }
    }
}
