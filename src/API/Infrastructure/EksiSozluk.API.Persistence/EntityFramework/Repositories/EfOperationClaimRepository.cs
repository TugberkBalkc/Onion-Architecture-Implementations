using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Persistence.EntityFramework.Contexts;
using EksiSozluk.API.Persistence.EntityFramework.Repositories.Common;

namespace EksiSozluk.API.Persistence.EntityFramework.Repositories
{
    public class EfOperationClaimRepository : EfRepositoryBase<Domain.Entities.OperationClaim>, IOperationClaimRepository
    {
        public EfOperationClaimRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
