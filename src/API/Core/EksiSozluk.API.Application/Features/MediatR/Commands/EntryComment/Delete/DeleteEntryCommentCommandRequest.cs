using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.Delete
{
    public class DeleteEntryCommentCommandRequest : IRequest<DeleteEntryCommentCommandResponse>
    {
        public Guid EntryCommentId { get; set; }
    }
}
