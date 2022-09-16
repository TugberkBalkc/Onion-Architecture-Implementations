using EksiSozluk.API.Application.Dtos.User;
using EksiSozluk.API.Application.Features.MediatR.Common;

namespace EksiSozluk.API.Application.Features.MediatR.Queries.GetAllUsersWithCount
{
    public class GetAllUsersWithCountQueryResponse : QueryResponseBase<List<GetUserDto>>
    {
    }
}
