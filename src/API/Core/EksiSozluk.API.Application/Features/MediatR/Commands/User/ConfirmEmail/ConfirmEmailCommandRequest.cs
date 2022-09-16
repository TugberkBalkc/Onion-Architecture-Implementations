﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommandRequest : IRequest<ConfirmEmailCommandResponse>
    {
        public Guid EmailConfirmationId { get; set; }
    }
}
