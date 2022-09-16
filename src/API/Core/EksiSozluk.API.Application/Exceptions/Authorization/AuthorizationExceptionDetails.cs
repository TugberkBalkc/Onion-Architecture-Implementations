using EksiSozluk.API.Application.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Exceptions.Authorization
{
    public class AuthorizationExceptionDetails : BaseExceptionDetails
    {
        public String RequestedUserName { get; set; }

        public override string ToString() => this.GetDetails(this);
    }
}
