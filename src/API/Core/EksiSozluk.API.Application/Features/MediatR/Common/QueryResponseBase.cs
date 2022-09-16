using EksiSozluk.API.Application.Utilities.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Common
{
    public class QueryResponseBase<TData>
    {
        public BaseDataBearerResponse<TData> Response { get; set; }
    }
}
