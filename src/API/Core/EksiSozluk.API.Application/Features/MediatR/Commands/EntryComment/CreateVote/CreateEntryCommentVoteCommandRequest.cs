using EksiSozluk.Shared.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.CreateVote
{
    public class CreateEntryCommentVoteCommandRequest : IRequest<CreateEntryCommentVoteCommandResponse>
    {
        public Guid EntryCommentId { get; set; }
        public Guid UserId { get; set; }
        public VoteType VoteType { get; set; }
    }
}
