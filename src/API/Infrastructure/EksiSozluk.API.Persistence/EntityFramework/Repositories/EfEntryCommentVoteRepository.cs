using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Persistence.EntityFramework.Contexts;
using EksiSozluk.API.Persistence.EntityFramework.Repositories.Common;

namespace EksiSozluk.API.Persistence.EntityFramework.Repositories
{
    public class EfEntryCommentVoteRepository : EfRepositoryBase<Domain.Entities.EntryCommentVote>, IEntryCommentVoteRepository
    {
        public EfEntryCommentVoteRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
