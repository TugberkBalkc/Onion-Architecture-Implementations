using EksiSozluk.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Domain.Entities
{
    public class RoleOperationClaim : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Guid OperationClaimId { get; set; }

        public virtual Role Role { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
    }
}
