using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Utilities.Responses.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllWithCount
{
    public class GetAllEntriesWithCountQueryRequest : IRequest<GetAllEntriesWithCountQueryResponse>
    {
        public int Count { get; set; } = PaginationConstantValues.DefaultQueryRequestCount;
    }
}
