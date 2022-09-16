using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.Delete
{
    public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>
    {
        public Guid UserId { get; set; }
    }
}
