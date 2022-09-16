using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Responses.Common
{
    public class BaseDataBearerResponse<T> : IDataBearerResponse<T>
    {
        public T Data { get; set; }
        public string Title { get; }
        public string Message { get; }
        public string DevNote { get; }
        public bool Success { get; }

        public BaseDataBearerResponse(T data, string title, string devNote, string message, bool success) : this(data, devNote, message, success)
        {
            Title = title;
        }

        public BaseDataBearerResponse(T data, string devNote, string message, bool success) : this(data, message, success)
        {
            DevNote = devNote;
        }

        public BaseDataBearerResponse(T data, string message, bool success) : this(data, success)
        {
            Message = message;
        }

        public BaseDataBearerResponse(T data, bool success)
        {
            Data = data;
            Success = success;
        }
    }
}
