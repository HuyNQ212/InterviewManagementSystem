using DataAccess.Models;

namespace DataAccess.Repositories.Implement
{
    public class CandidateStatusReposiroty : BaseRepository<CandidateStatus>, ICandidateStatus
    {
        public CandidateStatusReposiroty(InterviewManagementContext context) : base(context)
        {
        }
    }
}
