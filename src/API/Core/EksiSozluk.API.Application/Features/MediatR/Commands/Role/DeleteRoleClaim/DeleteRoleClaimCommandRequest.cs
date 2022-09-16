using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Role.RemoveClaim
{
    public class DeleteRoleClaimCommandRequest : IRequest<DeleteRoleClaimCommandResponse>
    {
        public Guid RoleId { get; set; }
        public Guid OperationClaimId { get; set; }

    }
}
