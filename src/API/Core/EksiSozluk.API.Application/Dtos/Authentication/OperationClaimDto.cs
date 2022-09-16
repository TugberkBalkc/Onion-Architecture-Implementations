using EksiSozluk.API.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.Authentication
{
    public class OperationClaimDto : IDto
    {
        public Guid OperationClaimId { get; set; }
        public DateTime OperationClaimCreateDate { get; set; }
        public DateTime OperationClaimModifyDate { get; set; }
        public bool OperationClaimIsActive { get; set; }
        public String OperationClaimName { get; set; }

        public OperationClaimDto()
        {

        }

        public OperationClaimDto(
            Guid operationClaimId, DateTime operationClaimCreateDate, DateTime operationClaimModifyDate, 
            bool operationClaimIsActive, string operationClaimName)
        {
            OperationClaimId = operationClaimId;
            OperationClaimCreateDate = operationClaimCreateDate;
            OperationClaimModifyDate = operationClaimModifyDate;
            OperationClaimIsActive = operationClaimIsActive;
            OperationClaimName = operationClaimName;
        }
    }
}
