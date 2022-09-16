using EksiSozluk.API.Application.Utilities.Responses.ServiceResponses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Responses.ServiceResponses
{
    public class SuccessfulServiceResponse : BaseServiceResponse
    {
        public SuccessfulServiceResponse(string title, string devNote, string message) : base(title, devNote, message, true)
        {
        }

        public SuccessfulServiceResponse(string title, string message) : base(title, message, true)
        {
        }

        public SuccessfulServiceResponse(string message) : base(message, true)
        {
        }

        public SuccessfulServiceResponse() : base(true)
        {
        }
    }
}
