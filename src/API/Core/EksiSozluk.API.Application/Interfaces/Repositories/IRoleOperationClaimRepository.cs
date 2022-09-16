using EksiSozluk.API.Application.Interfaces.Repositories.Common;
using EksiSozluk.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Interfaces.Repositories
{
    public interface IRoleOperationClaimRepository : IRepository<RoleOperationClaim>
    {
        ICollection<OperationClaim> GetRolesClaims(Guid roleId);
    }
}
