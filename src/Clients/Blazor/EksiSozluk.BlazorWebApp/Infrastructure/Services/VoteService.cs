using EksiSozluk.BlazorWebApp.Application.Interfaces;
using EksiSozluk.Shared.Core.Domain.Enums;

namespace EksiSozluk.BlazorWebApp.Infrastructure.Services
{
    public class VoteService : IVoteService
    {
        private readonly HttpClient _httpClient;

        public VoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task CreateEntryCommentDownVote(Guid entryId)
        {
            throw new NotImplementedException();
        }

        public Task CreateEntryCommentUpVote(Guid entryId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> CreateEntryCommentVote(Guid entryCommentId, VoteType voteType = VoteType.UpVote)
        {
            throw new NotImplementedException();
        }

        public Task CreateEntryDownVote(Guid entryId)
        {
            throw new NotImplementedException();
        }

        public Task CreateEntryUpVote(Guid entryId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> CreateEntryVote(Guid entryId, VoteType voteType = VoteType.UpVote)
        {
            throw new NotImplementedException();
        }
    }
}
