using AutoMapper;
using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Dtos.User;
using EksiSozluk.API.Application.Exceptions;
using EksiSozluk.API.Application.Features.MediatR.Rules.BusinessRules;
using EksiSozluk.API.Application.Interfaces.Repositories;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses;
using MediatR;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.UpdateRole
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommandRequest, UpdateUserRoleCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        private readonly IMapper _mapper;

        private readonly UserBusinessRules _userBusinessRules;

        public UpdateUserRoleCommandHandler
            (IUserRepository userRepository, IRoleRepository roleRepository,
            IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<UpdateUserRoleCommandResponse> Handle(UpdateUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetSingleAsync(u => u.Id == request.UserId);

            await _userBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.User>(user, BusinessConstants.User);

            var role = await _roleRepository
                .GetSingleAsync(r => r.Id == request.RoleId);

            await _userBusinessRules.NullCheck<EksiSozluk.API.Domain.Entities.Role>(role, BusinessConstants.Role);

            user.Role = role;

            var rows = _userRepository.UpdateAsync(user);

            var roleDto = _mapper.Map<RoleDto>(role);

            return new UpdateUserRoleCommandResponse()
            {
                Response =
                    new SuccessfulDataBearerServiceResponse<RoleDto>
                    (data: roleDto, title: ServerTitles.Successful, devNote: "", message: ServerMessages.UsersRoleUpdated)
            };
        }
    }
}
