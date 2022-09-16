using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Persistence.EntityFramework.Contexts;
using EksiSozluk.API.Persistence.EntityFramework.Repositories.Common;

namespace EksiSozluk.API.Persistence.EntityFramework.Repositories
{
    public class EfEntryVoteRepository : EfRepositoryBase<Domain.Entities.EntryVote>, IEntryVoteRepository
    {
        public EfEntryVoteRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
