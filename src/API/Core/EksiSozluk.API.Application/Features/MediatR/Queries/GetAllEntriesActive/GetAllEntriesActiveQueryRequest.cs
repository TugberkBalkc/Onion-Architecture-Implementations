using EksiSozluk.API.Application.Constansts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllEntriesActive
{
    public class GetAllEntriesActiveQueryRequest : IRequest<GetAllEntriesActiveQueryResponse>
    {
        public int Count { get; set; } = PaginationConstantValues.DefaultQueryRequestCount;
    }
}
