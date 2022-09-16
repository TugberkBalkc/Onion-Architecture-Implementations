using EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.Create;
using EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.CreateFavorite;
using EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.CreateVote;
using EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.Delete;
using EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.DeleteFavorite;
using EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.DeleteVote;
using EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryCommentsController : BaseController
    {
        private readonly IMediator _mediator;

        public EntryCommentsController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mediator = mediator;
        }


        #region Http Post&Put&Delete Requests
        [HttpPost("createentrycomment")]
        public async Task<IActionResult> CreateEntryComment([FromBody] CreateEntryCommentCommandRequest createEntryCommentCommandRequest)
        {
            if (this.CheckUserId(createEntryCommentCommandRequest.UserId) is false)
                createEntryCommentCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(createEntryCommentCommandRequest);

            return Ok(response);
        }

        [HttpPost("createentrycommentfavorite")]
        public async Task<IActionResult> CreateEntryCommentFavorite([FromBody] CreateEntryCommentFavoriteCommandRequest createEntryCommentFavoriteCommandRequest)
        {
            if (createEntryCommentFavoriteCommandRequest.UserId == Guid.Empty)
                createEntryCommentFavoriteCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(createEntryCommentFavoriteCommandRequest);

            return Ok(response);
        }

        [HttpDelete("deleteentrycommentfavorite")]
        public async Task<IActionResult> DeleteEntryCommentFavorite([FromBody] DeleteEntryCommentFavoriteCommandRequest deleteEntryCommentFavoriteCommandRequest)
        {
            if (deleteEntryCommentFavoriteCommandRequest.UserId == Guid.Empty)
                deleteEntryCommentFavoriteCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(deleteEntryCommentFavoriteCommandRequest);

            return Ok(response);
        }

        [HttpPost("createenrtycommentvote")]
        public async Task<IActionResult> CreateEntryCommentVote([FromBody] CreateEntryCommentVoteCommandRequest createEntryCommentVoteCommandRequest)
        {
            if (createEntryCommentVoteCommandRequest.UserId.ToString() is null)
                createEntryCommentVoteCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(createEntryCommentVoteCommandRequest);

            return Ok(response);
        }

        [HttpDelete("deleteentrycommentvote")]
        public async Task<IActionResult> DeleteEntryCommentVote([FromBody] DeleteEntryCommentVoteCommandRequest deleteEntryCommentVoteCommandRequest)
        {
            if (deleteEntryCommentVoteCommandRequest.UserId == Guid.Empty)
                deleteEntryCommentVoteCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(deleteEntryCommentVoteCommandRequest);

            return Ok(response);
        }

        [HttpDelete("deleteentrycomment")]
        public async Task<IActionResult> DeleteEntryComment([FromBody] DeleteEntryCommentCommandRequest deleteEntryCommentCommandRequest)
        {
      
            var response = await _mediator.Send(deleteEntryCommentCommandRequest);

            return Ok(response);
        }

        [HttpPut("updateentrycomment")]
        public async Task<IActionResult> UpdateEntryComment([FromBody] UpdateEntryCommentCommandRequest updateEntryCommentCommandRequest)
        {
            if (updateEntryCommentCommandRequest.UserId == Guid.Empty)
                updateEntryCommentCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(updateEntryCommentCommandRequest);

            return Ok(response);
        }
        #endregion
    }
}
