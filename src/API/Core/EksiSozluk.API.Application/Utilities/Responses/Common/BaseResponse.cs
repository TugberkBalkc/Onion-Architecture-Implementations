using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Responses.Common
{
    public class BaseResponse : IResponse
    {
        public string Title { get; }
        public string Message { get; }
        public string DevNote { get; }
        public bool Success { get; }


        public BaseResponse(string title, string devNote, string message, bool success) : this(devNote, message, success)
        {
            Title = title;
        }

        public BaseResponse(string devNote, string message, bool success) : this(message, success)
        {
            DevNote = devNote;
        }

        public BaseResponse(string message, bool success) : this(success)
        {
            Message = message;
        }

        public BaseResponse(bool success)
        {
            Success = success;
        }
    }
}
