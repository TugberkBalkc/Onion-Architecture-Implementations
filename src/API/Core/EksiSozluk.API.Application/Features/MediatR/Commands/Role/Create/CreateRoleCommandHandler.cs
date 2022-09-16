using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.User;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Logic;
using EksiSozluk.API.Application.Utilities.Responses;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Role.Create
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly RoleBusinessRules _roleBusinessRules;

        public CreateRoleCommandHandler
            (IRoleRepository roleRepository, IMapper mapper,
            RoleBusinessRules roleBusinessRules)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _roleBusinessRules = roleBusinessRules;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository
                .GetSingleAsync(r => r.Name.Trim().ToLower() == request.RoleName.Trim().ToLower());

            await _roleBusinessRules.ExistsCheck<EksiSozluk.API.Domain.Entities.Role>(role, BusinessConstants.Role);

            var mappedRole = _mapper.Map<Domain.Entities.Role>(request);

            var rows = await _roleRepository.AddAsync(mappedRole);

            var roleDto = _mapper.Map<RoleDto>(mappedRole);
            return new CreateRoleCommandResponse()
            {
                Response =
                new SuccessfulDataBearerServiceResponse<RoleDto>
                (data: roleDto, title: ServerTitles.Successful, devNote: "", message: ServerMessages.RoleCreated)
            };
        }
    }
}
