using EksiSozluk.API.Application.Constansts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllEntriesByContent
{
    public class GetAllEntriesByContentQueryRequest : IRequest<GetAllEntriesByContentQueryResponse>
    {
        public int Count { get; set; } = PaginationConstantValues.DefaultQueryRequestCount;
        public String EntryContent { get; set; }
    }
}
