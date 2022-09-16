using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Entry.Delete
{
    public class DeleteEntryCommandRequest : IRequest<DeleteEntryCommandResponse>
    {
        public Guid EntryId { get; set; }
    }
}
