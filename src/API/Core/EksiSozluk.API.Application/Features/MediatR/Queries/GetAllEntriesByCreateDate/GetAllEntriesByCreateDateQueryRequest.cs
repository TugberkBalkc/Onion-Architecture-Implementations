using EksiSozluk.API.Application.Constansts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllEntriesByCreateDate
{
    public class GetAllEntriesByCreateDateQueryRequest : IRequest<GetAllEntriesByCreateDateQueryResponse>
    {
        public int Count { get; set; } = PaginationConstantValues.DefaultQueryRequestCount;
        public DateTime StartCreateDate { get; set; } = DateTime.Now.AddDays(-7);
        public DateTime EndCreateDate { get; set; } = DateTime.Now;
    }
}
