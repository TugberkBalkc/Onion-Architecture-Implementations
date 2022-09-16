using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Domain.Entities;
using EksiSozluk.API.Persistence.EntityFramework.Contexts;
using EksiSozluk.API.Persistence.EntityFramework.Repositories.Common;

namespace EksiSozluk.API.Persistence.EntityFramework.Repositories
{
    public class EfRoleRepository : EfRepositoryBase<Domain.Entities.Role>, IRoleRepository
    {
        public EfRoleRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
