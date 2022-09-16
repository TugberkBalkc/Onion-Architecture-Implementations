using EksiSozluk.API.Application.Dtos.Entry;
using EksiSozluk.API.Application.Features.MediatR.Common;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllEntriesBySubject
{
    public class GetAllEntriesBySubjectQueryResponse : QueryResponseBase<List<GetEntryDto>>
    {
    }
}
