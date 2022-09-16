using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Features.MediatR.Common;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllEntriesByContent
{
    public class GetAllEntriesByContentQueryResponse : QueryResponseBase<List<GetEntryDto>>
    {
    }
}
