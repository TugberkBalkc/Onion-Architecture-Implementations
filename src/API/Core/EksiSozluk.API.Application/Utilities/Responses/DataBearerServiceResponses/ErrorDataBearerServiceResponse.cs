using EksiSozluk.API.Application.Utilities.Responses.Common;
using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses
{
    public class ErrorDataBearerServiceResponse<T> : BaseDataBearerServiceResponse<T>
    {

        public ErrorDataBearerServiceResponse(T data, string title, string devNote, string message) : base(data, title, devNote, message, false)
        {
        }

        public ErrorDataBearerServiceResponse(string title, string devNote, string message) : base(default, title, devNote, message, false)
        {
        }

        public ErrorDataBearerServiceResponse(T data, string devNote, string message) : base(data, devNote, message, false)
        {
        }

        public ErrorDataBearerServiceResponse(T data, string message) : base(data, message, false)
        {
        }

        public ErrorDataBearerServiceResponse(T data) : base(data, false)
        {
        }
    }
}
