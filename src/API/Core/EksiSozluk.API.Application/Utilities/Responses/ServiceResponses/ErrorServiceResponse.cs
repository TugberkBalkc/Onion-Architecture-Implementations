using EksiSozluk.API.Application.Utilities.Responses.Common;
using EksiSozluk.API.Application.Utilities.Responses.ServiceResponses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Responses.ServiceResponses
{
    public class ErrorServiceResponse : BaseServiceResponse
    {
        public ErrorServiceResponse(string title, string message) : base(title, message, false)
        {
        }

        public ErrorServiceResponse(string message) : base(message, false)
        {
        }

        public ErrorServiceResponse() : base(false)
        {
        }
    }
}
