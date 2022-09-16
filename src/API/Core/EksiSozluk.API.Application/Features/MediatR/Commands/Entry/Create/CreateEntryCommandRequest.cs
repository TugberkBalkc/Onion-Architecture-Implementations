using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.Entry.Create
{
    public class CreateEntryCommandRequest : IRequest<CreateEntryCommandResponse>
    {
        public Guid UserId { get; set; }

        public String EntrySubject { get; set; }
        public String EntryContent { get; set; }
    }
}
