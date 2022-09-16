using EksiSozluk.API.Application.Utilities.Responses.Common;
using EksiSozluk.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Responses.ServiceResponses.Common
{
    public class BaseServiceResponse : BaseResponse
    {
        public BaseServiceResponse(string title, string devNote, string message, bool success) : base(title, devNote, message, success)
        {
        }

        public BaseServiceResponse(string devNote, string message, bool success) : base(devNote, message, success)
        {
        }

        public BaseServiceResponse(string message, bool success) : base(message, success)
        {
        }

        public BaseServiceResponse(bool success) : base(success)
        {
        }
    }
}
