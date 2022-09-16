using EksiSozluk.API.Application.Constansts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllEntriesBySubject
{
    public class GetAllEntriesBySubjectQueryRequest : IRequest<GetAllEntriesBySubjectQueryResponse>
    {
        public int Count { get; set; } = PaginationConstantValues.DefaultQueryRequestCount;
        public String EntrySubject { get; set; }
    }
}
