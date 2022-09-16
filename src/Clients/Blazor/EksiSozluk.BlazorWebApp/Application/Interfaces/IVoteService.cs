

using EksiSozluk.Shared.Core.Domain.Enums;

namespace EksiSozluk.BlazorWebApp.Application.Interfaces
{
    public interface IVoteService
    {
        Task CreateEntryUpVote(Guid entryId);
        Task CreateEntryDownVote(Guid entryId);

        Task CreateEntryCommentUpVote(Guid entryId);
        Task CreateEntryCommentDownVote(Guid entryId);

        Task<HttpResponseMessage> CreateEntryVote(Guid entryId, VoteType voteType = VoteType.UpVote);
        Task<HttpResponseMessage> CreateEntryCommentVote(Guid entryCommentId, VoteType voteType = VoteType.UpVote);
    }
}
