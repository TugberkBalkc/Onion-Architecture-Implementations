using EksiSozluk.API.Application.Features.MediatR.Commands.Role.AddClaim;
using EksiSozluk.API.Application.Features.MediatR.Commands.Role.Create;
using EksiSozluk.API.Application.Features.MediatR.Commands.Role.Delete;
using EksiSozluk.API.Application.Features.MediatR.Commands.Role.Update;
using EksiSozluk.API.Application.Features.MediatR.Queries.GetRoleClaims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Http Post&Put&Delete Requests
        [HttpPost("createrole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommandRequest createRoleCommandRequest)
        {
            var response = await _mediator.Send(createRoleCommandRequest);

            return Ok(response);
        }

        [HttpPost("createroleclaim")]
        public async Task<IActionResult> AddClaim([FromBody] CreateRoleClaimCommandRequest addClaimCommandRequest)
        {
            var response = await _mediator.Send(addClaimCommandRequest);

            return Ok(response);
        }

        [HttpDelete("deleterole")]
        public async Task<IActionResult> DeleteRole([FromBody] DeleteRoleCommandRequest deleteRoleCommandRequest)
        {
            var response = await _mediator.Send(deleteRoleCommandRequest);

            return Ok(response);
        }

        [HttpPut("updaterole")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            var response = await _mediator.Send(updateRoleCommandRequest);

            return Ok(response);
        }
        #endregion


        [HttpGet("getroleclaims")]
        public async Task<IActionResult> GetRoleClaims([FromQuery] GetRoleClaimsQueryRequest getRoleClaimsQueryRequest)
        {
            var response = _mediator.Send(getRoleClaimsQueryRequest);

            return Ok(response);
        }
    }
}
