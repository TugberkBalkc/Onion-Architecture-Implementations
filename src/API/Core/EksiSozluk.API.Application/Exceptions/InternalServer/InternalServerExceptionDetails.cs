using EksiSozluk.API.Application.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Exceptions.InternalServer
{
    public class InternalServerExceptionDetails : BaseExceptionDetails
    {
        public String ServerName { get; set; }
        public override string ToString() => this.GetDetails(this);
    }
}
