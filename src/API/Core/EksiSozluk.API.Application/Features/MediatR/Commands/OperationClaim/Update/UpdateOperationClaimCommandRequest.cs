using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.OperationClaim.Update
{
    public class UpdateOperationClaimCommandRequest : IRequest<UpdateOperationClaimCommandResponse>
    {
        public Guid OperationClaimId { get; set; }
        public String OperationClaimName { get; set; }

        public UpdateOperationClaimCommandRequest()
        {

        }

        public UpdateOperationClaimCommandRequest(string operationClaimName)
        {
            OperationClaimName = operationClaimName;
        }
    }
}
