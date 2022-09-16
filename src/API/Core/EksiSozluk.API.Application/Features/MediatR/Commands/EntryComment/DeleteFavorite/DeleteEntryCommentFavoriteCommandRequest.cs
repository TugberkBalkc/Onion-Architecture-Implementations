using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.DeleteFavorite
{
    public class DeleteEntryCommentFavoriteCommandRequest : IRequest<DeleteEntryCommentFavoriteCommandResponse>
    {
        public Guid EntryCommentId { get; set; }
        public Guid UserId { get; set; }
    }
}
