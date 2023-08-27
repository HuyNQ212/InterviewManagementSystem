using DataAccess.Models;

namespace DataAccess.Repositories.Implement
{
    public class CandidateSkillRepository : BaseRepository<CandidateSkill>, ICandidateSkillRepository
    {
        public CandidateSkillRepository(InterviewManagementContext context) : base(context)
        {
        }
    }
}
