using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Features.MediatR.Common;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllWithCount
{
    public class GetAllEntriesWithCountQueryResponse : QueryResponseBase<List<GetEntryDto>>
    {
    }
}
