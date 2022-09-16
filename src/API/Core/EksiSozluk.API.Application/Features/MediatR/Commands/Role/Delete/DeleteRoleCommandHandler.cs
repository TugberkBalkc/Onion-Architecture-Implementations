using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Role.Delete
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly RoleBusinessRules _roleBusinessRules;

        public DeleteRoleCommandHandler
            (IRoleRepository roleRepository, IMapper mapper,
             RoleBusinessRules roleBusinessRules)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _roleBusinessRules = roleBusinessRules;
        }

        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository
                .GetSingleAsync(r => r.Id == request.RoleId);

            await _roleBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.Role>(role, BusinessConstants.Role);

            var rows = await _roleRepository.DeleteAsync(role);

            return new DeleteRoleCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<Guid>
                (data: request.RoleId, title: ServerTitles.Successful, devNote: "", message: ServerMessages.RoleDeleted)
            };
        }
    }
}
