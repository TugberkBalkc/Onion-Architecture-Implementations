using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Persistence.EntityFramework.Contexts;
using EksiSozluk.API.Persistence.EntityFramework.Repositories.Common;

namespace EksiSozluk.API.Persistence.EntityFramework.Repositories
{
    public class EfEntryFavoriteRepository : EfRepositoryBase<Domain.Entities.EntryFavorite>, IEntryFavoriteRepository
    {
        public EfEntryFavoriteRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
