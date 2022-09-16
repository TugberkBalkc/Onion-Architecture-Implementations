using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Persistence.EntityFramework.Contexts;
using EksiSozluk.API.Persistence.EntityFramework.Repositories.Common;

namespace EksiSozluk.API.Persistence.EntityFramework.Repositories
{
    public class EfEntryCommentRepository : EfRepositoryBase<Domain.Entities.EntryComment>, IEntryCommentRepository
    {
        public EfEntryCommentRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
