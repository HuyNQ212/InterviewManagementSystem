using DataAccess.Models;

namespace DataAccess.Repositories.Implement
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(InterviewManagementContext context) : base(context)
        {
        }
    }
}
