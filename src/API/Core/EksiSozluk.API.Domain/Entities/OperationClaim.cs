using EksiSozluk.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Domain.Entities
{
    public class OperationClaim : BaseEntity
    { 
        public String Name { get; set; }

        public virtual ICollection<RoleOperationClaim> RoleOperationClaims { get; set; }
    }
}
