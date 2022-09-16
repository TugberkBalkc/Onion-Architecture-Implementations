using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.User;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Role.Update
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly RoleBusinessRules _roleBusinessRules;

        public UpdateRoleCommandHandler
            (IRoleRepository roleRepository, IMapper mapper,
             RoleBusinessRules roleBusinessRules)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _roleBusinessRules = roleBusinessRules;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository
                .GetSingleAsync(r => r.Id == request.RoleId);

            await _roleBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.Role>(role, BusinessConstants.Role);

            var rows = await _roleRepository.UpdateAsync(role);

            var roleDto = _mapper.Map<RoleDto>(role);

            return new UpdateRoleCommandResponse()
            {
                Response =
               new SuccessfulDataBearerServiceResponse<RoleDto>
               (data: roleDto, title: ServerTitles.Successful, devNote: "", message: ServerMessages.RoleUpdate)
            };
        }
    }
}
