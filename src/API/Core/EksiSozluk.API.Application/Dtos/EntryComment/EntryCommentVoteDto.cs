using EksiSozluk.API.Application.Dtos.Common;
using EksiSozluk.Shared.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.EntryComment
{
    public class EntryCommentVoteDto : IDto
    {
        public Guid EntryCommentVoteId { get; set; }
        public DateTime EntryCommentVoteCreateDate { get; set; }
        public DateTime EntryCommentVoteModifyDate { get; set; }
        public bool EntryCommentVoteIsActive { get; set; }
        public Guid EntryCommentId { get; set; }
        public Guid UserId { get; set; }

        public VoteType VoteType { get; set; }

        public EntryCommentVoteDto()
        {

        }

        public EntryCommentVoteDto(Guid entryCommentId, Guid userId, VoteType voteType)
        {
            EntryCommentId = entryCommentId;
            UserId = userId;
            VoteType = voteType;
        }

        public EntryCommentVoteDto(
            Guid entryCommentVoteId, DateTime entryCommentVoteCreateDate, DateTime entryCommentVoteModifyDate,
            bool entryCommentVoteIsActive, Guid entryCommentId, Guid userId, 
            VoteType voteType)
        {
            EntryCommentVoteId = entryCommentVoteId;
            EntryCommentVoteCreateDate = entryCommentVoteCreateDate;
            EntryCommentVoteModifyDate = entryCommentVoteModifyDate;
            EntryCommentVoteIsActive = entryCommentVoteIsActive;
            EntryCommentId = entryCommentId;
            UserId = userId;
            VoteType = voteType;
        }
    }
}
