using EksiSozluk.Shared.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Shared.Events.Entry
{
    public class CreateEntryVoteEvent
    {
        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }

        public VoteType VoteType { get; set; }
    }
}
