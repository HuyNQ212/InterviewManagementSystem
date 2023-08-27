using DataAccess.Models;

namespace DataAccess.Repositories.Implement
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(InterviewManagementContext context) : base(context)
        {
        }

        public void SomethingElse()
        {
            
        }
    }
}
