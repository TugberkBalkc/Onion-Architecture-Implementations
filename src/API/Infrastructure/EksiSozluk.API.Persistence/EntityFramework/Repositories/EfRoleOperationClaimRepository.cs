using EksiSozluk.API.Application.Dtos.Authentication;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Domain.Entities;
using EksiSozluk.API.Persistence.EntityFramework.Contexts;
using EksiSozluk.API.Persistence.EntityFramework.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Persistence.EntityFramework.Repositories
{
    public class EfRoleOperationClaimRepository : EfRepositoryBase<Domain.Entities.RoleOperationClaim>, IRoleOperationClaimRepository
    {
        public EfRoleOperationClaimRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }

        public ICollection<OperationClaim> GetRolesClaims(Guid roleId)
        {
            var result = from roleOperationClaim in this._dbContext.Set<RoleOperationClaim>()
                         join role in this._dbContext.Set<Role>()
                         on roleOperationClaim.RoleId equals role.Id
                         join operationClaim in this._dbContext.Set<OperationClaim>()
                         on roleOperationClaim.OperationClaimId equals operationClaim.Id
                         where roleOperationClaim.RoleId == roleId
                         select new OperationClaim()
                         {
                             Id = operationClaim.Id,
                             CreateDate = operationClaim.CreateDate,
                             ModifyDate = operationClaim.ModifyDate,
                             IsActive = operationClaim.IsActive,
                             Name = operationClaim.Name
                         };

            return result.ToList();
        }
    }

}
