using EksiSozluk.API.Application.Features.MediatR.Commands.User.ChangePassword;
using EksiSozluk.API.Application.Features.MediatR.Commands.User.ConfirmEmail;
using EksiSozluk.API.Application.Features.MediatR.Commands.User.Create;
using EksiSozluk.API.Application.Features.MediatR.Commands.User.Delete;
using EksiSozluk.API.Application.Features.MediatR.Commands.User.Login;
using EksiSozluk.API.Application.Features.MediatR.Commands.User.Update;
using EksiSozluk.API.Application.Features.MediatR.Commands.User.UpdateRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EksiSozluk.API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mediator = mediator;
        }


        #region Http Post&Put&Delete Requests
        [HttpPost("loginuserwithrole")]
        public async Task<IActionResult> LoginWithRole([FromBody] LoginUserWithRoleCommandRequest loginUserWithRoleCommandRequest)
        {
            var response = await _mediator.Send(loginUserWithRoleCommandRequest);

            return Ok(response);
        }

        [HttpPost("loginuserwithoperationclaims")]
        public async Task<IActionResult> LoginOperationClaims([FromBody] LoginUserWithOperationClaimsCommandRequest loginUserWithOperationClaimsCommandRequest)
        {
            var response = await _mediator.Send(loginUserWithOperationClaimsCommandRequest);

            return Ok(response);
        }

        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest createUserCommandRequest)
        {
            var response = await _mediator.Send(createUserCommandRequest);

            return Ok(response);
        }

        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest updateUserCommandRequest)
        {
            if (updateUserCommandRequest.UserId == Guid.Empty)
                updateUserCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(updateUserCommandRequest);

            return Ok(response);
        }

        [HttpPut("updateuserrole")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleCommandRequest updateUserRoleCommandRequest)
        {
            if (updateUserRoleCommandRequest.UserId == Guid.Empty)
                updateUserRoleCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(updateUserRoleCommandRequest);

            return Ok(response);
        }

        [HttpPut("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommandRequest changeUserPasswordCommandRequest)
        {
            if (changeUserPasswordCommandRequest.UserId == Guid.Empty)
                changeUserPasswordCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(changeUserPasswordCommandRequest);

            return Ok(response);
        }


        [HttpPut("confirmemail")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailCommandRequest confirmEmailCommandRequest)
        {
            var response = await _mediator.Send(confirmEmailCommandRequest);

            return Ok(response);
        }

        [HttpDelete("deleteuser")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommandRequest deleteUserCommandRequest)
        {
            if (deleteUserCommandRequest.UserId == Guid.Empty)
                deleteUserCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(deleteUserCommandRequest);

            return Ok(response);
        }
        #endregion
    }
}
