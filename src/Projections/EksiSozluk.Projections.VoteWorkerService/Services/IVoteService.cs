using EksiSozluk.Shared.Events.Entry;
using EksiSozluk.Shared.Events.EntryComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Projections.VoteWorkerService.Services
{
    public interface IVoteService
    {
        Task CreateEntryVote(CreateEntryVoteEvent @createEntryVoteEvent);
        Task DeleteEntryVote(DeleteEntryVoteEvent @deleteEntryVoteEvent);   

        Task CreateEntryCommentVote(CreateEntryCommentVoteEvent createEntryCommentVoteEvent);
        Task DeleteEntryCommentVote(DeleteEntryCommentVoteEvent deleteEntryCommentVoteEvent);
    }
}
