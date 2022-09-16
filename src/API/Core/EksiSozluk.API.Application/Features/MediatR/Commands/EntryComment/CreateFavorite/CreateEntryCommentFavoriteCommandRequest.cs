using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.EntryComment.CreateFavorite
{
    public class CreateEntryCommentFavoriteCommandRequest : IRequest<CreateEntryCommentFavoriteCommandResponse>
    {
        public Guid EntryCommentId { get; set; }
        public Guid UserId { get; set; }
    }
}
