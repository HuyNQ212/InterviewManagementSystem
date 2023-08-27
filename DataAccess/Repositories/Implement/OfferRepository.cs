using DataAccess.Models;

namespace DataAccess.Repositories.Implement
{
    public class OfferRepository : BaseRepository<Offer>, IOfferRepository
    {
        public OfferRepository(InterviewManagementContext context) : base(context)
        {
        }
    }
}
