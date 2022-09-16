using EksiSozluk.API.Application.Features.MediatR.Commands.OperationClaim.Create;
using EksiSozluk.API.Application.Features.MediatR.Commands.OperationClaim.Delete;
using EksiSozluk.API.Application.Features.MediatR.Commands.OperationClaim.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OperationClaimsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Http Post&Put&Delete Requests
        [HttpPost("createoperationclaim")]
        public async Task<IActionResult> CreateOperationClaim([FromBody] CreateOperationClaimCommandRequest createOperationClaimCommandRequest)
        {
            var response = await _mediator.Send(createOperationClaimCommandRequest);

            return Ok(response);
        }

        [HttpDelete("deleteoperationclaim")]
        public async Task<IActionResult> DeleteOperationClaim([FromBody] DeleteOperationClaimCommandRequest deleteOperationClaimCommandRequest)
        {
            var response = await _mediator.Send(deleteOperationClaimCommandRequest);

            return Ok(response);
        }

        [HttpPut("updateoperationclaim")]
        public async Task<IActionResult> UpdateOperationClaim([FromBody] UpdateOperationClaimCommandRequest updateOperationClaimCommandRequest)
        {
            var response = await _mediator.Send(updateOperationClaimCommandRequest);

            return Ok(response);
        }

        #endregion
    }
}
