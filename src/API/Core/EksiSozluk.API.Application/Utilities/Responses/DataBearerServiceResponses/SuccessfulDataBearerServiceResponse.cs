using EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses
{
    public class SuccessfulDataBearerServiceResponse<T> : BaseDataBearerServiceResponse<T>
    {
        public SuccessfulDataBearerServiceResponse(T data, string title, string devNote, string message) : base(data, title, devNote, message, true)
        {
        }

        public SuccessfulDataBearerServiceResponse(T data, string devNote, string message) : base(data, devNote, message, true)
        {
        }

        public SuccessfulDataBearerServiceResponse(T data, string message) : base(data, message, true)
        {
        }

        public SuccessfulDataBearerServiceResponse(T data) : base(data, true)
        {
        }
    }
}
