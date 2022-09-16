using EksiSozluk.API.Application.Features.MediatR.Commands.Entry.AddFavorite;
using EksiSozluk.API.Application.Features.MediatR.Commands.Entry.Create;
using EksiSozluk.API.Application.Features.MediatR.Commands.Entry.CreateVote;
using EksiSozluk.API.Application.Features.MediatR.Commands.Entry.Delete;
using EksiSozluk.API.Application.Features.MediatR.Commands.Entry.DeleteVote;
using EksiSozluk.API.Application.Features.MediatR.Commands.Entry.RemoveFavorite;
using EksiSozluk.API.Application.Features.MediatR.Commands.Entry.Update;
using EksiSozluk.API.Application.Features.MediatR.Queries.GetAllEntriesByCreateDate;
using EksiSozluk.API.Application.Features.MediatR.Queries.GetAllWithCount;
using EksiSozluk.API.Application.Features.MediatR.Queries.GetTodaysEntries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : BaseController
    {
        private readonly IMediator _mediator;

        public EntriesController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mediator = mediator;
        }

        #region Http Post&Put&Delete Requests
        [HttpPost("createentry")]
        public async Task<IActionResult> CreateEntry([FromBody] CreateEntryCommandRequest createEntryCommandRequest)
        {
            if (createEntryCommandRequest.UserId == Guid.Empty)
                createEntryCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(createEntryCommandRequest);

            return Ok(response);
        }

        [HttpPost("createentryfavorite")]
        public async Task<IActionResult> CreateEntryFavorite([FromBody] CreateEntryFavoriteCommandRequest createFavoriteCommandRequest)
        {
            if (createFavoriteCommandRequest.UserId == Guid.Empty)
                createFavoriteCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(createFavoriteCommandRequest);

            return Ok(response);
        }

        [HttpDelete("deleteentryfavorite")]
        public async Task<IActionResult> DeleteEntryFavorite([FromBody] DeleteEntryFavoriteCommandRequest deleteFavoriteCommandRequest)
        {
            if (deleteFavoriteCommandRequest.UserId == Guid.Empty)
                deleteFavoriteCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(deleteFavoriteCommandRequest);

            return Ok(response);
        }

        [HttpPost("createentryvote")]
        public async Task<IActionResult> CreateEntryVote([FromBody] CreateEntryVoteCommandRequest createEntryVoteCommandRequest)
        {
            if (createEntryVoteCommandRequest.UserId == Guid.Empty)
                createEntryVoteCommandRequest.UserId = this._userId;

            var response = await _mediator.Send(createEntryVoteCommandRequest);

            return Ok(response);
        }

        [HttpDelete("deleteentryvote")]
        public async Task<IActionResult> DeleteEntryVote([FromBody] DeleteEntryVoteCommandRequest deleteEntryVoteCommandRequest)
        {
            if (deleteEntryVoteCommandRequest.UserId == Guid.Empty)
                deleteEntryVoteCommandRequest.UserId = this._userId;
            
            var response = await _mediator.Send(deleteEntryVoteCommandRequest);

            return Ok(response);
        }

        [HttpDelete("deleteentry")]
        public async Task<IActionResult> DeleteEntry([FromBody] DeleteEntryCommandRequest deleteEntryCommandRequest)
        {
          
            var response = await _mediator.Send(deleteEntryCommandRequest);

            return Ok(response);
        }

        [HttpPut("updateentry")]
        public async Task<IActionResult> UpdateEntry([FromBody] UpdateEntryCommandRequest updateEntryCommandRequest)
        {
            var response = await _mediator.Send(updateEntryCommandRequest);

            return Ok(response);
        }
        #endregion

        #region Http Get Requests
        [HttpGet("getallentriesbycount")]
        public async Task<IActionResult> GetAllEntriesByCount([FromQuery] GetAllEntriesWithCountQueryRequest getAllEntriesWithCountQueryRequest)
        {
            var response = await _mediator.Send(getAllEntriesWithCountQueryRequest);

            return Ok(response);
        }

        [HttpGet("getallentriesbycreatedate")]
        public async Task<IActionResult> GetAllEntriesByCreateDate([FromQuery] GetAllEntriesByCreateDateQueryRequest getAllEntriesByCreateDateQueryRequest)
        {
            var response = await _mediator.Send(getAllEntriesByCreateDateQueryRequest);

            return Ok(response);
        }

        [HttpGet("gettodaysentries")]
        public async Task<IActionResult> GetTodaysEntries([FromQuery] GetTodaysEntriesQueryRequest getTodaysEntriesQueryRequest)
        {
            var response = await _mediator.Send(getTodaysEntriesQueryRequest);

            return Ok(response);
        }

        //[HttpGet("getallentryvotes")]
        //public async Task<IActionResult> GetAllEntryVotes([FromQuery] GetAllEntryVotesQueryRequest getAllEntryVotesQueryRequest)
        //{
        //    var response = await _mediator.Send(getAllEntryVotesQueryRequest);

        //    return Ok(response);
        //}
        #endregion
    }
}
