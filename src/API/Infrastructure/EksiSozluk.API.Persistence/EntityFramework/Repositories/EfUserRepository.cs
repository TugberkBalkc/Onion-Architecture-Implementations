using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Persistence.EntityFramework.Contexts;
using EksiSozluk.API.Persistence.EntityFramework.Repositories.Common;

namespace EksiSozluk.API.Persistence.EntityFramework.Repositories
{
    public class EfUserRepository : EfRepositoryBase<Domain.Entities.User>, IUserRepository
    {
        public EfUserRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
