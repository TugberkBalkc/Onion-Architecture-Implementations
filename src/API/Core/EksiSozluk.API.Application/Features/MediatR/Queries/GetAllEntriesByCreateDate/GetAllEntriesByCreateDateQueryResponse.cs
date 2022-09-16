using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Features.MediatR.Common;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllEntriesByCreateDate
{
    public class GetAllEntriesByCreateDateQueryResponse : QueryResponseBase<List<GetEntryDto>>
    {
    }
}
