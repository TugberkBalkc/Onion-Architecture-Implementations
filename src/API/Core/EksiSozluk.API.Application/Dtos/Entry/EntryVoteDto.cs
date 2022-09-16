using EksiSozluk.API.Application.Dtos.Common;
using EksiSozluk.Shared.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Dtos.Entry
{
    public class EntryVoteDto : IDto
    {
        public Guid EntryVoteId { get; set; }
        public DateTime EntryVoteCreateDate { get; set; }
        public DateTime EntryVoteModifyDate { get; set; }
        public bool EntryVoteIsActive { get; set; }
        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }

        public VoteType VoteType { get; set; }

        public EntryVoteDto()
        {

        }

        public EntryVoteDto(Guid entryId, Guid userId, VoteType voteType)
        {
            EntryId = entryId;
            UserId = userId;
            VoteType = voteType;
        }

        public EntryVoteDto(
            Guid entryVoteId, DateTime entryVoteCreateDate, DateTime entryVoteModifyDate, 
            bool entryVoteIsActive, Guid entryId, Guid userId, 
            VoteType voteType)
        {
            EntryVoteId = entryVoteId;
            EntryVoteCreateDate = entryVoteCreateDate;
            EntryVoteModifyDate = entryVoteModifyDate;
            EntryVoteIsActive = entryVoteIsActive;
            EntryId = entryId;
            UserId = userId;
            VoteType = voteType;
        }
    }
}
