using EksiSozluk.API.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.Authentication
{
    public class RoleOperationClaimDto : IDto
    {
        public Guid RoleOperationClaimId { get; set; }
        public DateTime RoleOperationClaimCreateDate { get; set; }
        public DateTime RoleOperationClaimModifyDate { get; set; }
        public bool RoleOperationClaimIsActive { get; set; }
        public Guid RoleId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}
