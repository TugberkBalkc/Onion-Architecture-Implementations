using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.Update
{
    public class UpdateEntryCommentCommandRequest : IRequest<UpdateEntryCommentCommandResponse>
    {
        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }
        public String EntryCommentContent { get; set; }
    }
}
