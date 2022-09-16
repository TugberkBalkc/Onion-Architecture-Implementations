using EksiSozluk.API.Application.Utilities.Responses.Common;
using EksiSozluk.API.Application.Utilities.Responses.ServiceResponses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Responses.DataBearerServiceResponses.Common
{
    public class BaseDataBearerServiceResponse<T> : BaseDataBearerResponse<T>
    {
        public BaseDataBearerServiceResponse(T data, string title, string devNote, string message, bool success) : base(data, title, devNote, message, success)
        {
        }

        public BaseDataBearerServiceResponse(T data, string devNote, string message, bool success) : base(data, devNote, message, success)
        {
        }

        public BaseDataBearerServiceResponse(T data, string message, bool success) : base(data, message, success)
        {
        }

        public BaseDataBearerServiceResponse(T data, bool success) : base(data, success)
        {
        }
    }
}
