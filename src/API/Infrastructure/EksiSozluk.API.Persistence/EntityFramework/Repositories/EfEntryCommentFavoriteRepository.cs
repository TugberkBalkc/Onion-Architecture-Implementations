using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Persistence.EntityFramework.Contexts;
using EksiSozluk.API.Persistence.EntityFramework.Repositories.Common;

namespace EksiSozluk.API.Persistence.EntityFramework.Repositories
{
    public class EfEntryCommentFavoriteRepository : EfRepositoryBase<Domain.Entities.EntryCommentFavorite>, IEntryCommentFavoriteRepository
    {
        public EfEntryCommentFavoriteRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
