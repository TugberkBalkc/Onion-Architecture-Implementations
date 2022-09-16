using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Responses.Common
{
    public interface IDataBearerResponse<T> : IResponse
    {
        T Data { get; }
    }
}
