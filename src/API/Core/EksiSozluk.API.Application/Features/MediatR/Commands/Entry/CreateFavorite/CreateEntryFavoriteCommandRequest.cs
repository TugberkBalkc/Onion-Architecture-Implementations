using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Entry.AddFavorite
{
    public class CreateEntryFavoriteCommandRequest : IRequest<CreateEntryFavoriteCommandResponse>
    {
        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }
    }
}
